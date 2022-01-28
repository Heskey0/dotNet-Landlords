using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using QFramework.Example;
using UnityEngine;

public class UserHandler : HandlerBase
{
    public override void OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case (int)SubCode.User.CreateUser_SRes:
                createUser(value);
                break;
            
            case (int)SubCode.User.Online_SRes:
                online(value);
                break;
            
            case (int)SubCode.User.GetUser_SRes:
                getUser(value);
                break;
        }
    }

    void createUser(object value)
    {
        switch ((int)value)
        {
            case -1:
                NetMgr.Instance.SendMsg(new EventMsg("非法登录",NetEvent.ReceivePropmpt));
                break;
            case -2:
                NetMgr.Instance.SendMsg(new EventMsg("已经创建过角色",NetEvent.ReceivePropmpt));
                break;
            case 0:
                //创建角色成功
                Debug.Log("创建角色成功");
                SocketMsg socketMsg = SocketMsgPool.Instance.Allocate(
                    (int)OpCode.User,
                    (int)SubCode.User.GetUser_CReq,
                    null
                    );
                NetMgr.Instance.SendMsg(new EventMsg(socketMsg,NetEvent.Send));
                break;
        }
    }

    void online(object value)
    {
        
    }

    void getUser(object value)
    {
        var dto = value as UserDto;
        if (dto==null)
        {
            Debug.Log("角色信息为空");
            return;
        }

        GameModel.Instance.selfUserDto = dto;
        Debug.Log("获取角色成功");
        PanelPlayerInfoData.Instance.Refresh(dto);
        UIKit.OpenPanel<PanelUID>(UILevel.PopUI);
        UIKit.ClosePanel<PanelCreate>();
    }
}
