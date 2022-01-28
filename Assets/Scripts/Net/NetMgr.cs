using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using QFramework.Example;
using UnityEngine;


//[MonoSingletonPath("[Net]/NetMgr")]
public class NetMgr : QMgrBehaviour, ISingleton
{
    private ClientPeer client = new ClientPeer("127.0.0.1", 9999);

    public override int ManagerId
    {
        get => QMgrID.Network;
    }

    public static NetMgr Instance
    {
        get => MonoSingletonProperty<NetMgr>.Instance;
    }

    public void OnSingletonInit()
    {
    }

    private void Start()
    {
        client.Connect();
    }

    #region 处理服务器发来的消息

    HandlerBase accountHandler = new AccountHandler();
    HandlerBase userHandler = new UserHandler();
    HandlerBase matchHandler = new MatchHandler();
    HandlerBase chatHandler = new ChatHandler();
    HandlerBase fightHandler = new FightHandler();

    private void Update()
    {
        if (client == null)
            return;

        while (client.SocketMsgQueue.Count > 0)
        {
            SocketMsg msg = client.SocketMsgQueue.Dequeue();
            //处理消息
            processSocketMsg(msg);
        }
    }

    /// <summary>
    /// 处理网络消息
    /// </summary>
    /// <param name="msg"></param>
    private void processSocketMsg(SocketMsg msg)
    {
        //NetMgr.Instance.SendMsg(new NetMsg(msg.Value,NetEvent.ReceivePropmpt));
        switch (msg.OpCode)
        {
            case (int) OpCode.Account:
                accountHandler.OnReceive(msg.SubCode, msg.Value);
                break;
            case (int) OpCode.User:
                userHandler.OnReceive(msg.SubCode, msg.Value);
                break;
            case (int) OpCode.Match:
                matchHandler.OnReceive(msg.SubCode, msg.Value);
                break;
            case (int) OpCode.Chat:
                chatHandler.OnReceive(msg.SubCode, msg.Value);
                break;
            case (int) OpCode.Fight:
                fightHandler.OnReceive(msg.SubCode, msg.Value);
                break;
            default:
                break;
        }
    }

    #endregion

    /// <summary>
    /// QMsgCenter发来的消息
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="msg"></param>
    protected override void ProcessMsg(int eventId, QMsg msg)
    {
        switch (eventId)
        {
            case NetEvent.Send:
                SocketMsg socketMsg = (msg as EventMsg).Msg as SocketMsg;

                client.Send(socketMsg);
                SocketMsgPool.Instance.Recycle(socketMsg);
                break;
            case NetEvent.ReceivePropmpt:
                UIKit.OpenPanel<PanelPrompt>(new PanelPromptData((msg as EventMsg).Msg as string));
                break;

            default:
                break;
        }

        base.ProcessMsg(eventId, msg);
    }
}