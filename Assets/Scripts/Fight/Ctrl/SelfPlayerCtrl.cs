using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using UnityEngine;
using DG.Tweening;

public class SelfPlayerCtrl : QMonoBehaviour
{
    public override IManager Manager
    {
        get => PlayerManager.Instance;
    }
    
    private void Awake()
    {
        RegisterEvents(GameEvent.SelfCard.Add_SelfCard,
            GameEvent.SelfCard.Init_SelfCard,
            GameEvent.SelfCard.Remove_SelfCard,
            GameEvent.SelfCard.Deal_SelfCard
        );
    }

    protected override void ProcessMsg(int eventId, QMsg msg)
    {
        switch (eventId)
        {
            case (int)GameEvent.SelfCard.Add_SelfCard:
                addTableCard((msg as EventMsg).Msg as GrabDto);
                break;
            
            case (int)GameEvent.SelfCard.Init_SelfCard:
                StartCoroutine(initCardList((msg as EventMsg).Msg as List<CardDto>));
                break;
            
            case (int)GameEvent.SelfCard.Remove_SelfCard:
                removeCard((msg as EventMsg).Msg as List<CardDto>);
                break;         
            
            case (int)GameEvent.SelfCard.Deal_SelfCard:
                dealSelectCard();
                break;
        }
    }
    
    ResLoader mResLoader = ResLoader.Allocate ();
    private List<CardCtrl> cardCtrlList;
    
    private Transform cardParent;
    private SocketMsg socketMsg;
    
    void Start()
    {
        cardParent = transform.Find("CardPoint");
        cardCtrlList = new List<CardCtrl>();
    }


    private void dealSelectCard()
    {
        List<CardDto> selectCardList = getSelectCard();
        DealDto dto = new DealDto(selectCardList, GameModel.Instance.selfUserDto.Id);
        if (dto.IsRegular == false)
        {
            //出牌不合法
            //TODO
            UIManager.Instance.SendMsg(new EventMsg("请选择合理的手牌！",NetEvent.ReceivePropmpt));
            UIManager.Instance.SendMsg(new EventMsg(null,(int)UIEventEnum.Fight.ShowDealButton));
            
            return;
        }
        else
        {
            //可以出牌
            socketMsg = SocketMsgPool.Instance.Allocate(
                (int)OpCode.Fight,
                (int)SubCode.Fight.Deal_Creq,
                dto
            );
            UIManager.Instance.SendMsg(new EventMsg(socketMsg,NetEvent.Send));
        }
    }
    private List<CardDto> getSelectCard()
    {
        List<CardDto> selectCardList = new List<CardDto>();
        foreach (var cardCtrl in cardCtrlList)
        {
            if (cardCtrl.Selected == true)
            {
                selectCardList.Add(cardCtrl.CardDto);
            }
        }
        return selectCardList;
    }
    
    private void removeCard(List<CardDto> remainCardList)
    {
        int index = 0;
        foreach (var cc in cardCtrlList)
        {
            if (remainCardList.Count == 0)
                break;
            else
            {
                cc.gameObject.SetActive(true);
                cc.Init(remainCardList[index], index, true);
                index++;
                //没有牌了
                if (index == remainCardList.Count)
                {
                    break;
                }
            }
        }
        //把index之后的牌 都隐藏掉
        for (int i = index; i < cardCtrlList.Count; i++)
        {
            cardCtrlList[i].Selected = false;
            cardCtrlList[i].gameObject.SetActive(false);
        }
    }
    
    private void addTableCard(GrabDto dto)
    {
        List<CardDto> tableCards = dto.TableCardList;
        List<CardDto> playerCards = dto.PlayerCardList;
        
        int index = 0;
        foreach (var cardCtrl in cardCtrlList)
        {
            cardCtrl.gameObject.SetActive(true);
            cardCtrl.Init(playerCards[index], index, true);
            //if (tableCards.Contains())
            //    cardCtrl.SelectState();
            index++;
        }
        //再创建新的三张卡牌
        var cardPrefab = mResLoader.LoadSync<GameObject>("CardPrefab");
        for (int i = index; i < playerCards.Count; i++)
        {
            createGo(playerCards[i], i, cardPrefab);
        }
    }
    private IEnumerator initCardList(List<CardDto> cardList)
    {
        var cardPrefab = mResLoader.LoadSync<GameObject>("CardPrefab");

        for (int i = 0; i < cardList.Count; i++)
        {
            createGo(cardList[i], i, cardPrefab);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    private void createGo(CardDto card, int index, GameObject cardPrefab)
    {
        GameObject cardGo = Instantiate(cardPrefab, cardParent);
        cardGo.name = card.Name;
        cardGo.GetComponent<BoxCollider>().enabled = false;
        cardGo.transform.DOLocalMove(new Vector2((0.25f * index), 0), 0.8f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                this.Delay(0.5f, () =>
                {
                    cardGo.GetComponent<BoxCollider>().enabled = true;
                });
            });
        
        CardCtrl cardCtrl = cardGo.GetComponent<CardCtrl>();
        cardCtrl.Init(card, index, true);

        //存储本地
        cardCtrlList.Add(cardCtrl);
    }
}