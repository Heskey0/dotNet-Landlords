using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using UnityEngine;
using Object = UnityEngine.Object;

public class DeskCtrl : QMonoBehaviour
{
    public override IManager Manager
    {
        get => PlayerManager.Instance;
    }

    private void Awake()
    {
        RegisterEvent(GameEvent.DeskCard.UpdateDesk);
    }

    protected override void ProcessMsg(int eventId, QMsg msg)
    {
        switch (eventId)
        {
            case (int)GameEvent.DeskCard.UpdateDesk:
                updateShowDesk((msg as EventMsg).Msg as List<CardDto>);
                break;
        }
    }
    
    ResLoader mResLoader = ResLoader.Allocate();
    
    private List<CardCtrl> cardCtrlList;
    private Transform cardParent;


    void Start()
    {
        cardParent = transform.Find("CardPoint");
        cardCtrlList = new List<CardCtrl>();
    }

    private void updateShowDesk(List<CardDto> cardList)
    {
        //33 34567
        //34567  3

        if (cardCtrlList.Count > cardList.Count)
        {
            //原来比现在多
            int index = 0;
            foreach (var cardCtrl in cardCtrlList)
            {
                cardCtrl.gameObject.SetActive(true);
                cardCtrl.Init(cardList[index], index, true);
                index++;
                //如果牌没了
                if (index == cardList.Count)
                {
                    break;
                }
            }
            for (int i = index; i < cardCtrlList.Count; i++)
            {
                cardCtrlList[i].gameObject.SetActive(false);
            }
        }
        else
        {
            int index = 0;
            foreach (var cardCtrl in cardCtrlList)
            {
                cardCtrl.gameObject.SetActive(true);
                cardCtrl.Init(cardList[index], index, true);
                index++;
            }
            //再创建新的n张卡牌
            var cardPrefab  = mResLoader.LoadSync<GameObject>("CardPrefab");
            for (int i = index; i < cardList.Count; i++)
            {
                createGo(cardList[i], i, cardPrefab);
            }
        }
    }
    
    private void createGo(CardDto card, int index, GameObject cardPrefab)
    {
        GameObject cardGo = Object.Instantiate(cardPrefab, cardParent) as GameObject;
        cardGo.name = card.Name;
        cardGo.transform.localPosition = new Vector2((0.3f * index), 0);
        CardCtrl cardCtrl = cardGo.GetComponent<CardCtrl>();
        cardCtrl.Init(card, index, true);

        //存储本地
        cardCtrlList.Add(cardCtrl);
    }
}
