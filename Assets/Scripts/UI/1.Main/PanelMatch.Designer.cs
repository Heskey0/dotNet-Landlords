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
    
    
    // Generate Id:6e23be47-8baf-44bd-b909-24b6c5fbc8d9
    public partial class PanelMatch
    {
        
        public const string NAME = "PanelMatch";
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnCancel;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnEnter;
        
        private PanelMatchData mPrivateData = null;
        
        public PanelMatchData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelMatchData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelMatchData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            BtnCancel = null;
            BtnEnter = null;
            mData = null;
        }
    }
}
