using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class EncodeTool
{
    #region Packet

    public static byte[] EncodePacket(byte[] src)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                bw.Write(src.Length);
                bw.Write(src);
                byte[] dst = new byte[ms.Length];
                Buffer.BlockCopy(ms.GetBuffer(), 0, dst, 0, (int) ms.Length);
                return dst;
            }
        }
    }

    public static byte[] DecodePacket(ref List<byte> dataCache)
    {
        if (dataCache.Count < 4)
            return null;

        using (MemoryStream ms = new MemoryStream(dataCache.ToArray()))
        {
            using (BinaryReader br = new BinaryReader(ms))
            {
                int length = br.ReadInt32();
                int dataRemainLength = (int)(ms.Length - ms.Position);
                if (length > dataRemainLength)
                    return null;

                byte[] data = br.ReadBytes(length);
                dataCache.Clear();

                dataCache.AddRange(br.ReadBytes(dataRemainLength));

                return data;
            }
        }
    }

    #endregion

    #region Msg

    public static SocketMsg EncodeMsg(byte[] src)
    {
        using (MemoryStream ms = new MemoryStream(src))
        {
            using (BinaryReader br = new BinaryReader(ms))
            {
                SocketMsg dst = new SocketMsg();
                dst.OpCode = br.ReadInt32();
                dst.SubCode = br.ReadInt32();
                if (ms.Length > ms.Position)
                {
                    dst.Value = EncodeObj(br.ReadBytes((int) (ms.Length - ms.Position)));
                }

                return dst;
            }
        }
    }

    public static byte[] DecodeMsg(SocketMsg src)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                bw.Write(src.OpCode);
                bw.Write(src.SubCode);
                if (src.Value != null)
                {
                    bw.Write(DecodeObj(src.Value));
                }

                byte[] dst = new byte[ms.Length];
                Buffer.BlockCopy(ms.GetBuffer(), 0, dst, 0, (int) ms.Length);
                return dst;
            }
        }
    }

    #endregion

    #region Obj

    public static object EncodeObj(byte[] src)
    {
        using (MemoryStream ms = new MemoryStream(src))
        {
            BinaryFormatter bf = new BinaryFormatter();
            object dst = bf.Deserialize(ms);
            return dst;
        }
    }

    public static byte[] DecodeObj(object src)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, src);
            byte[] dst = new byte[ms.Length];
            Buffer.BlockCopy(ms.GetBuffer(), 0, dst, 0, (int) ms.Length);
            return dst;
        }
    }

    #endregion
    
}