using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using QFramework;
using UnityEngine;

public class LeftPlayerCtrl : QMonoBehaviour
{
    public override IManager Manager
    {
        get => PlayerManager.Instance;
    }

    private void Awake()
    {
        RegisterEvents(GameEvent.LeftCard.Add_LeftCard,
            GameEvent.LeftCard.Init_LeftCard,
            GameEvent.LeftCard.Remove_LeftCard
            );
    }

    protected override void ProcessMsg(int eventId, QMsg msg)
    {
        switch (eventId)
        {
            case (int)GameEvent.LeftCard.Add_LeftCard:
                addTableCard();
                break;
            
            case (int)GameEvent.LeftCard.Init_LeftCard:
                StartCoroutine(initCardList());
                break;
            
            case (int)GameEvent.LeftCard.Remove_LeftCard:
                removeCard(((msg as EventMsg).Msg as List<CardDto>).Count);
                break;
        }
    }
    
    ResLoader mResLoader = ResLoader.Allocate ();
    
    private List<GameObject> cardObjectList;
    private Transform cardParent;
    
    void Start()
    {
        cardParent = transform.Find("CardPoint");
        cardObjectList = new List<GameObject>();
    }
    
    private void removeCard( int cardCount )
    {
        for (int i = cardCount; i < cardObjectList.Count; i++)
        {
            cardObjectList[i].SetActive(false);
        }
    }
    
    private void addTableCard()
    {
        var cardPrefab = mResLoader.LoadSync<GameObject>("BackCardPrefab");
        for (int i = 0; i < 3; i++)
        {
            createGo(i, cardPrefab);
        }
    }
    private IEnumerator initCardList()
    {
        var cardPrefab = mResLoader.LoadSync<GameObject>("BackCardPrefab");

        for (int i = 0; i < 17; i++)
        {
            createGo(i, cardPrefab);
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void createGo(int index, GameObject cardPrefab)
    {
        GameObject cardGo = Instantiate(cardPrefab, cardParent);
        cardGo.transform.localPosition = new Vector2((0.15f * index), 0);
        cardGo.GetComponent<SpriteRenderer>().sortingOrder = index;

        cardObjectList.Add(cardGo);
    }
}
