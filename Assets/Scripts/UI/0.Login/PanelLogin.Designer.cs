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
    
    
    // Generate Id:90072b2b-1142-4fd3-9a24-6558eae8805a
    public partial class PanelLogin
    {
        
        public const string NAME = "PanelLogin";
        
        private PanelLoginData mPrivateData = null;
        
        public PanelLoginData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelLoginData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelLoginData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            mData = null;
        }
    }
}