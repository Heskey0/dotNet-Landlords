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
    
    
    // Generate Id:a5ff374e-9c14-4e4c-8f34-6c8b556283aa
    public partial class PanelRightPlayer
    {
        
        public const string NAME = "PanelRightPlayer";
        
        [SerializeField()]
        public UnityEngine.UI.Image ImgPlayer;
        
        [SerializeField()]
        public UnityEngine.UI.Text TxtState;
        
        [SerializeField()]
        public UnityEngine.UI.Image ImgChat;
        
        [SerializeField()]
        public UnityEngine.UI.Image ImgCard;
        
        private PanelRightPlayerData mPrivateData = null;
        
        public PanelRightPlayerData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelRightPlayerData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelRightPlayerData());
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
            ImgChat = null;
            ImgCard = null;
            mData = null;
        }
    }
}
