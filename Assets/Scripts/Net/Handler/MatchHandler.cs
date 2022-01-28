using UnityEngine;
using Protocol;
using QFramework;
using QFramework.Example;
using UnityEditor;


public class MatchHandler : HandlerBase
{
    public override void OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case (int) SubCode.Match.Enter_SRes:
                enterResponce(value as MatchRoomDto);
                break;
            case (int) SubCode.Match.Enter_BRO:
                enterBroadcast(value as UserDto);
                break;
            case (int) SubCode.Match.Leave_BRO:
                leaveBroadcast((int)value);
                break;
            case (int) SubCode.Match.Ready_BRO:
                readyBroadcast((int)value);
                break;
            case (int) SubCode.Match.Start_BRO:
                startBroadcast();
                break;
        }
    }

    private void enterResponce(MatchRoomDto dto)
    {
        GameModel.Instance.RoomDto = dto;
        
        Debug.Log("进入房间："+dto.RoomId);
        UIManager.Instance.SendEvent(UIEventEnum.Main.ShowEnterButton);
    }

    private void enterBroadcast(UserDto dto)
    {
        GameModel.Instance.Add(-1,dto);
        if (GameModel.Instance.LeftPlayer>=0)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.LeftEnter);
        }

        if (GameModel.Instance.RightPlayer>=0)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.RightEnter);
        }
    }

    private void leaveBroadcast(int uid)
    {
        if (GameModel.Instance.LeftPlayer>=0)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.LeftLeave);
        }

        if (GameModel.Instance.RightPlayer>=0)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.RightLeave);
        }
        GameModel.Instance.Remove(uid,uid);
    }

    private void readyBroadcast(int readyUid)
    {
        GameModel.Instance.Add(readyUid,null);
        if (GameModel.Instance.LeftPlayer == readyUid)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.LeftReady);
        }
        else if (GameModel.Instance.RightPlayer == readyUid)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.RightReady);
        }
    }

    private void startBroadcast()
    {
        //UIManager.Instance.SendMsg(new EventMsg(null, (int) UIEventEnum.Fight.HideState));
        UIKit.OpenPanel<PanelUp>();
    }
    
}