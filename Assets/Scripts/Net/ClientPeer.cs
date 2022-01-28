using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using QFramework;
using QFramework.Example;
using UnityEngine;
using Object = UnityEngine.Object;

public class ClientPeer
{
    Socket socket;
    private string ip;
    private int port;
    
    private byte[] receiveBuffer = new byte[1024];
    private List<byte> dataCache = new List<byte>();
    private bool isProcessingReceive = false;
    public Queue<SocketMsg> SocketMsgQueue = new Queue<SocketMsg>();
    

    public ClientPeer(string ip, int port)
    {
        this.ip = ip;
        this.port = port;
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
    public void Connect()
    {
        try
        {
            socket.Connect(ip, port);
            startReceive();
        }
        catch (Exception e)
        {
            NetMgr.Instance.SendMsg(new EventMsg("服务器未开启",NetEvent.ReceivePropmpt));
            Debug.LogError(e.Message);
        }
    }

    #region Receive

    

    void startReceive()
    {
        if (socket == null && !socket.Connected)
        {
            Debug.LogError("没有连接成功，无法发送数据");
            return;
        }

        socket.BeginReceive(receiveBuffer,0,1024,SocketFlags.None,receiveCallback,socket);
    }

    void receiveCallback(IAsyncResult ar)
    {
        try
        {
            int length = socket.EndReceive(ar);
            byte[] tmpByteArray = new byte[length];
            Buffer.BlockCopy(receiveBuffer, 0, tmpByteArray, 0, length);
            
            dataCache.AddRange(tmpByteArray);
            if (isProcessingReceive == false)
                processReceive();

            startReceive();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void processReceive()
    {
        isProcessingReceive = true;
        byte[] data = EncodeTool.DecodePacket(ref dataCache);
        if (data==null)
        {
            isProcessingReceive = false;
            return;
        }

        SocketMsg socketMsg = EncodeTool.EncodeMsg(data);
        SocketMsgQueue.Enqueue(socketMsg);
        
        //NetMgr.Instance.SendMsg(new NetMsg(socketMsg.Value));
        processReceive();
    }

    #endregion

    #region Send

    public void Send(int opCode, int subCode, Object value)
    {
        try
        {
            byte[] packet = EncodeTool.EncodePacket(EncodeTool.DecodeMsg(new SocketMsg(opCode, subCode, value)));
            socket.Send(packet);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }


    public void Send(SocketMsg msg)
    {
        try
        {
            byte[] packet = EncodeTool.EncodePacket(EncodeTool.DecodeMsg(msg));
            socket.Send(packet);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    #endregion
}