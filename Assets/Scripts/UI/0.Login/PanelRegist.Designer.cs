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
    
    
    // Generate Id:0d80f540-e3ca-4b7f-bdca-8aa60fee306b
    public partial class PanelRegist
    {
        
        public const string NAME = "PanelRegist";
        
        private PanelRegistData mPrivateData = null;
        
        public PanelRegistData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelRegistData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelRegistData());
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
