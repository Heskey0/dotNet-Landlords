using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using QFramework.Example;
using UnityEngine;

public class FightHandler : HandlerBase
{
    public override void OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case (int)SubCode.Fight.GetCard_Sres:
                getCards(value as List<CardDto>);
                break;
            case (int)SubCode.Fight.TurnGrab_Bro:
                turnGrabBro((int)value);
                break;
            case (int)SubCode.Fight.GrabLandlord_Bro:
                grabLandlordBro(value as GrabDto);
                break;
            case (int)SubCode.Fight.TurnDeal_Bro:
                turnDealBro((int)value);
                break;
            case (int)SubCode.Fight.Deal_Bro:
                dealBro(value as DealDto);
                break;
            case (int)SubCode.Fight.Deal_Sres:
                dealResponse((int)value);
                break;
            case (int)SubCode.Fight.Pass_Sres:
                if ((int)value == -1)
                {
                    NetMgr.Instance.SendMsg(new EventMsg("不能不出",NetEvent.ReceivePropmpt));
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.ShowDealButton);
                }
                break;
            default:
                break;
        }
    }
    
    private void getCards(List<CardDto> cardList)
    {
        PlayerManager.Instance.SendMsg(
            new EventMsg(cardList,(int)GameEvent.SelfCard.Init_SelfCard));
        PlayerManager.Instance.SendMsg(
            new EventMsg(null,(int)GameEvent.LeftCard.Init_LeftCard));
        PlayerManager.Instance.SendMsg(
            new EventMsg(null,(int)GameEvent.RightCard.Init_RightCard));
    }
    
    private bool isFirst = true;
    private void turnGrabBro(int userId)
    {
        if (isFirst == true)
        {
            isFirst = false;
        }
        //如果是自身 就显示 两个抢地主和不抢地主的按钮
        if (userId == GameModel.Instance.selfUserDto.Id)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.ShowGrabButton);
        }
    }
    private void grabLandlordBro(GrabDto dto)
    {
        UIManager.Instance.SendMsg(new EventMsg(dto.UserId,(int)UIEventEnum.Fight.PlayerChangeIdentity));
        UIManager.Instance.SendMsg(new EventMsg(dto.TableCardList,(int)UIEventEnum.Fight.SetTableCards));
        int eventCode = -1;
        if (dto.UserId == GameModel.Instance.LeftPlayer)
        {
            eventCode = (int)GameEvent.LeftCard.Add_LeftCard;
        }
        else if (dto.UserId == GameModel.Instance.RightPlayer)
        {
            eventCode = (int)GameEvent.RightCard.Add_RightCard;
        }
        else if (dto.UserId == GameModel.Instance.selfUserDto.Id)
        {
            eventCode = (int)GameEvent.SelfCard.Add_SelfCard;
        }
        PlayerManager.Instance.SendMsg(new EventMsg(dto,eventCode));
        UIKit.ClosePanel<PanelUp>();
    }
    private void turnDealBro(int userId)
    {
        if (GameModel.Instance.selfUserDto.Id == userId)
        {
            UIManager.Instance.SendEvent(UIEventEnum.Fight.ShowDealButton);
        }
    }
    

    private void dealBro(DealDto dto)
    {
        //移除出完的手牌
        int eventCode = -1;
        if (dto.UserId == GameModel.Instance.LeftPlayer)
        {
            eventCode = (int)GameEvent.LeftCard.Remove_LeftCard;
        }
        else if (dto.UserId == GameModel.Instance.RightPlayer)
        {
            eventCode = (int)GameEvent.RightCard.Remove_RightCard;
        }
        else if (dto.UserId == GameModel.Instance.selfUserDto.Id)
        {
            eventCode = (int)GameEvent.SelfCard.Remove_SelfCard;
        }
        PlayerManager.Instance.SendMsg(new EventMsg(dto.RemainCardList,eventCode));
        //显示到桌面上
        PlayerManager.Instance.SendMsg(new EventMsg(dto.SelectCardList,(int)GameEvent.DeskCard.UpdateDesk));
        //TODO 播放出牌音效
    }
    
    private void dealResponse(int result)
    {
        if (result == -1)
        {
            //玩家出的牌管不上上一个玩家出的牌
            NetMgr.Instance.SendMsg(new EventMsg("玩家出的牌管不上上一个玩家出的牌",(int)NetEvent.ReceivePropmpt));

            //重新显示出牌按钮
            UIManager.Instance.SendMsg(new EventMsg(null,(int)UIEventEnum.Fight.ShowDealButton));
        }
    }
}
