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
    
    
    // Generate Id:aff1f3ab-11b0-4439-ab7a-836bb5048b63
    public partial class PanelSelfPlayer
    {
        
        public const string NAME = "PanelSelfPlayer";
        
        [SerializeField()]
        public UnityEngine.UI.Image ImgPlayer;
        
        [SerializeField()]
        public UnityEngine.UI.Text TxtState;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnReady;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnGrab;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnNotGrab;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnDeal;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnNotDeal;
        
        [SerializeField()]
        public UnityEngine.UI.Image ImgCard;
        
        private PanelSelfPlayerData mPrivateData = null;
        
        public PanelSelfPlayerData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelSelfPlayerData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelSelfPlayerData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            ImgPlayer = null;
            TxtState = null;
            BtnReady = null;
            BtnGrab = null;
            BtnNotGrab = null;
            BtnDeal = null;
            BtnNotDeal = null;
            ImgCard = null;
            mData = null;
        }
    }
}
