using QFramework;
using UnityEngine;

public class SocketMsgPool : Pool<SocketMsg>
{
    #region Singleton

    private SocketMsgPool() { }

    private static SocketMsgPool _instance;

    public static SocketMsgPool Instance
    {
        get
        {
            _instance.IsNull().Do(() => _instance = new SocketMsgPool());
            return _instance;
        }
    }

    #endregion

    public SocketMsg Allocate(int opCode, int subCode, object value)
    {
        SocketMsg socketMsg = Allocate();
        socketMsg.OpCode = opCode;
        socketMsg.SubCode = subCode;
        socketMsg.Value = value;
        return socketMsg;
    }

    public override bool Recycle(SocketMsg obj)
    {
        mCacheStack.Push(obj);
        return true;
    }
}