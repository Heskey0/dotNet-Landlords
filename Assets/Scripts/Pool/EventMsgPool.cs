using QFramework;
using UnityEngine;

public class EventMsgPool : SingletonPoolBase<EventMsgPool,EventMsg>
{
    public EventMsg Allocate(object msg,int eventId)
    {
        EventMsg eventMsg = Allocate();
        eventMsg.Msg = msg;
        eventMsg.EventID = eventId;
        return eventMsg;
    }
}