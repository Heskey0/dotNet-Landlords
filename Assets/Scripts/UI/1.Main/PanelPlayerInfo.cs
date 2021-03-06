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
    using UniRx;
    using Protocol;
    
    
    public class PanelPlayerInfoData : QFramework.UIPanelData
    {
        public ReactiveProperty<int> Id =  new ReactiveProperty<int>();
        public ReactiveProperty<string> Name = new ReactiveProperty<string>("你的名字");
        public ReactiveProperty<int> Lv =  new ReactiveProperty<int>(1);
        public ReactiveProperty<float> Exp = new ReactiveProperty<float>(0.6f);
        public ReactiveProperty<int> Been = new ReactiveProperty<int>(0);

        #region Refresh

        public void Refresh(int id,string name,int lv,float exp,int been)
        {
            this.Id.Value = id;
            this.Name.Value = name;
            this.Lv.Value = lv;
            this.Exp.Value = exp;
            this.Been.Value = been;
        }
         
        public void Refresh(UserDto dto)
        {
            this.Id.Value = dto.Id;
            this.Name.Value = dto.Name;
            this.Lv.Value = dto.Lv;
            this.Exp.Value = dto.Exp;
            this.Been.Value = dto.Been;

            Debug.Log(this.Name.Value+"：角色信息刷新成功");
        }

        #endregion
        
        #region Singleton

        private static PanelPlayerInfoData _instance;
        public static PanelPlayerInfoData Instance
        {
            get
            {
                _instance.IsNull().Do(() =>
                {
                    _instance = new PanelPlayerInfoData();
                });
                return _instance;
            }
        }
        
        #endregion
    }
    
    public partial class PanelPlayerInfo : QFramework.UIPanel
    {
        
        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            
        }
        
        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as PanelPlayerInfoData ?? new PanelPlayerInfoData();
            // please add init code here
            
            mData = PanelPlayerInfoData.Instance;
            
            mData.Name.SubscribeToText(TxtName);
            mData.Lv.SubscribeToText(TxtLv);
            mData.Exp.Subscribe(_ =>
            {
                SldExp.value = mData.Exp.Value;
            });
            mData.Been.SubscribeToText(TxtBean);
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
    }
}
