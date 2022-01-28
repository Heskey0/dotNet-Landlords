using System.Collections;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using DG.Tweening;
using QFramework;

public class CardCtrl : MonoBehaviour
{
    public CardDto CardDto { get; private set; }
    public bool Selected { get; set; }

    private SpriteRenderer spriteRenderer;
    private bool isMine;

    private ResLoader mResLoader = ResLoader.Allocate();
    
    public void Init(CardDto card, int index, bool isMine)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.CardDto = card;
        this.isMine = isMine;
        //为了重用
        if (Selected == true)
        {
            Selected = false;
            transform.DOMoveY(transform.position.y - 0.3f, 0.5f)
                .SetEase(Ease.InQuart);
        }
        string resName = string.Empty;
        if (isMine)
        {
            resName = card.Name;
        }
        else
        {
            resName = "CardBack";
        }
        
        Sprite sp = mResLoader.LoadSprite(resName);
        spriteRenderer.sprite = sp;
        spriteRenderer.sortingOrder = index;
    }


    private void OnMouseDown()
    {
        if (isMine == false)
            return;

        this.Selected = !Selected;
        if(Selected == true)
        {
            transform.DOMoveY(transform.position.y + 0.3f, 0.5f)
                .SetEase(Ease.OutQuart);
        }
        else
        {
            transform.DOMoveY(transform.position.y - 0.3f, 0.5f)
                .SetEase(Ease.InQuart);
        }
    }


    public void SelectState()
    {
        if(Selected == false)
        {
            this.Selected = true;
            transform.DOMoveY(transform.position.y + 0.3f, 0.5f)
                .SetEase(Ease.OutQuart);
        }
    }
}
