using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using QFramework.Example;
using UnityEngine;


public class AccountHandler : HandlerBase
{
    public override void OnReceive(int subCode,object value)
    {
        
        switch (subCode)
        {
            case (int)SubCode.Account.Login:
                login(value);
                break;
            
            case (int)SubCode.Account.Rigist_SRes:
                regist(value);
                break;
            
            default:
                break;
        }
    }

    void login(object value)
    {
        switch ((int)value)
        {
            case 1:    //登录成功 创建过角色
                SceneMgr.Instance.Load(1, () =>
                {
                    UIKit.CloseAllPanel();
                    UIKit.OpenPanel<PanelMainBg>(UILevel.Bg);
                    UIKit.OpenPanel<PanelPlayerInfo>(UILevel.Bg);
                    SocketMsg socketMsg = SocketMsgPool.Instance.Allocate(
                        (int)OpCode.User,
                        (int)SubCode.User.GetUser_CReq,
                        null);
                    
                    
                    NetMgr.Instance.SendMsg(new EventMsg(socketMsg, NetEvent.Send));

                });
                break;
            
            case 0:    //登录成功 没创建过角色
                SceneMgr.Instance.Load(1, () =>
                {
                    UIKit.CloseAllPanel();
                    UIKit.OpenPanel<PanelMainBg>(UILevel.Bg);
                    UIKit.OpenPanel<PanelPlayerInfo>(UILevel.Bg);
                    UIKit.OpenPanel<PanelCreate>();
                });
                break;
            case -1:
                NetMgr.Instance.SendMsg(new EventMsg("账号不存在",NetEvent.ReceivePropmpt));
                break;         
            case -2:
                NetMgr.Instance.SendMsg(new EventMsg("账号密码不匹配",NetEvent.ReceivePropmpt));
                break; 
            case -3:
                NetMgr.Instance.SendMsg(new EventMsg("账号已在线",NetEvent.ReceivePropmpt));
                break;
            default:
                break;
        }
    }   
    void regist(object value)
    {
        switch ((int)value)
        {
            case 0:
                NetMgr.Instance.SendMsg(new EventMsg("注册成功",NetEvent.ReceivePropmpt));
                break;
            case -1:
                NetMgr.Instance.SendMsg(new EventMsg("账号已存在",NetEvent.ReceivePropmpt));
                break;         
            case -2:
                NetMgr.Instance.SendMsg(new EventMsg("账号或密码为空",NetEvent.ReceivePropmpt));
                break; 

            default:
                break;
        }
    }
}
