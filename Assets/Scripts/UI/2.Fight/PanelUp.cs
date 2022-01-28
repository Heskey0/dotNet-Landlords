//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QFramework.Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using Protocol;
    
    
    public class PanelUpData : QFramework.UIPanelData
    {
    }
    
    public partial class PanelUp : QFramework.UIPanel
    {
        private ResLoader mResLoader = ResLoader.Allocate();
        
        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            switch (eventId)
            {
                case (int)UIEventEnum.Fight.SetTableCards:
                    setTableCards((msg as EventMsg).Msg as List<CardDto>);
                    break;
            }
        }
        
        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as PanelUpData ?? new PanelUpData();
            // please add init code here
            RegisterEvent(UIEventEnum.Fight.SetTableCards);
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
        private void setTableCards(List<CardDto> cards)
        {
            ImgCard1.sprite = mResLoader.LoadSprite(cards[0].Name);
            ImgCard2.sprite = mResLoader.LoadSprite(cards[1].Name);
            ImgCard3.sprite = mResLoader.LoadSprite(cards[2].Name);
        }
    }
}