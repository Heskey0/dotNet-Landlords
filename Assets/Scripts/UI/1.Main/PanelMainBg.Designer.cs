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
    
    
    // Generate Id:40f29e6b-e97e-440f-8b54-d6e0efcad1cc
    public partial class PanelMainBg
    {
        
        public const string NAME = "PanelMainBg";
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnStart;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnSetting;
        
        private PanelMainBgData mPrivateData = null;
        
        public PanelMainBgData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelMainBgData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelMainBgData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            BtnStart = null;
            BtnSetting = null;
            mData = null;
        }
    }
}
