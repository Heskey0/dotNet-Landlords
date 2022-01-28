using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public static class UIEventEnum
{
    
    public enum Login
    {
        Start = QMgrID.UI,
        OpenLogin,    //打开登录Panel
        OpenRegist,
        CloseLogin,
        CloseRegist,
        Login,
        Regist,
        End
    }
    
    public enum Main
    {
        Start = Login.End,
        OpenSetting,
        OpenMatch,
        CloseSetting,
        CloseMatch,
        ShowEnterButton,
        ExitGame,

        
        End
    }
    
    public enum Fight
    {
        Start=Main.End,
        
        LeftEnter,
        RightEnter,
        
        LeftLeave,
        RightLeave,
        
        LeftReady,
        RightReady,
        
        SetTableCards,
        
        ShowGrabButton,
        ShowDealButton,
        
        HideState,
        
        PlayerChangeIdentity,

        #region Chat
        LeftChat1,
        LeftChat2,
        LeftChat3,
        RightChat1,
        RightChat2,
        RightChat3,
        SelfChat1,
        SelfChat2,
        SelfChat3,
        #endregion

        
        End
    }
}
