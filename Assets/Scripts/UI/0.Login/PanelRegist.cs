//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Protocol;

namespace QFramework.Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class PanelRegistData : QFramework.UIPanelData
    {
    }
    
    public partial class PanelRegist : QFramework.UIPanel
    {
        private InputField inputFieldAccount;
        private InputField inputFieldPassword;
        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            switch (eventId)
            {
                case (int)UIEventEnum.Login.CloseRegist:
                    UIKit.ClosePanel<PanelRegist>();
                    break;
                case (int)UIEventEnum.Login.Regist:
                    AccountDto accountDto = new AccountDto(inputFieldAccount.text, inputFieldPassword.text);
                    SocketMsg socketMsg = new SocketMsg((int) OpCode.Account, (int) SubCode.Account.Rigist_CReq, accountDto);
                 
                    SendMsg(new EventMsg(socketMsg,NetEvent.Send));
                    break;
            }
        }
        
        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as PanelRegistData ?? new PanelRegistData();
            // please add init code here
            inputFieldAccount= gameObject.Find<InputField>("InputFieldAccount");
            inputFieldPassword= gameObject.Find<InputField>("InputFieldPassword");
            
            RegisterEvent(UIEventEnum.Login.CloseRegist);
            RegisterEvent(UIEventEnum.Login.Regist);
            
            gameObject.Find<Button>("BtnClose").onClick.AddListener(()=>
            {
                SendEvent(UIEventEnum.Login.CloseRegist);
            });
            gameObject.Find<Button>("BtnRegist").onClick.AddListener(() =>
            {
                if (string.IsNullOrEmpty(inputFieldAccount.text)
                    ||string.IsNullOrEmpty(inputFieldPassword.text) )
                {
                    return;
                }
                SendEvent(UIEventEnum.Login.Regist);
            });
        }
        
        protected override void OnOpen(QFramework.IUIData uiData)
        {
        }
        
        protected override void OnShow()
        {
        }
        
        protected override void OnHide()
        {
        }
        
        protected override void OnClose()
        {
        }
    }
}
