using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class NetEvent
{
    public const int Send = QMgrID.Network + 1;
    public const int ReceivePropmpt = Send + 1;
}

public class GameEvent
{
    public enum SelfCard
    {
        Start = QMgrID.Game + 1,
        Init_SelfCard,
        Add_SelfCard,
        Remove_SelfCard,
        Deal_SelfCard,
        
        End
    }

    public enum LeftCard
    {
        Start = SelfCard.End,
        Init_LeftCard,
        Add_LeftCard,
        Remove_LeftCard,
        
        End
    }


    public enum RightCard
    {
        Start = LeftCard.End,
        
        Init_RightCard,
        Add_RightCard,
        Remove_RightCard,
        
        End
    }
    
    public enum DeskCard
    {
        Start = RightCard.End,
        
        UpdateDesk,
        
        End
    }

}