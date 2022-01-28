using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketMsg
{
    public int OpCode;
    public int SubCode;
    public object Value;

    public SocketMsg()
    {
    }

    public SocketMsg(int opCode, int subCode, object value)
    {
        this.OpCode = opCode;
        this.SubCode = subCode;
        this.Value = value;
    }
}