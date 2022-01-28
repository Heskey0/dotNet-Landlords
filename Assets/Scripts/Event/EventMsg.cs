using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;


public class EventMsg : QMsg
{
    public object Msg = null;

    public EventMsg() { }
    public EventMsg(object msg, int eventid) : base(eventid)
    {
        this.Msg = msg;
    }
}