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
    
    
    // Generate Id:d3485ced-2fdd-415c-bf22-5f6497f71ec3
    public partial class PanelOver
    {
        
        public const string NAME = "PanelOver";
        
        [SerializeField()]
        public UnityEngine.UI.Text TxtWinner;
        
        [SerializeField()]
        public UnityEngine.UI.Button BtnBack;
        
        private PanelOverData mPrivateData = null;
        
        public PanelOverData Data
        {
            get
            {
                return mData;
            }
        }
        
        PanelOverData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelOverData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            TxtWinner = null;
            BtnBack = null;
            mData = null;
        }
    }
}