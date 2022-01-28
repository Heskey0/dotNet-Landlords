//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UniRx;

namespace QFramework.Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class PanelSettingData : QFramework.UIPanelData
    {
        #region Singleton
        private static PanelSettingData _instance;
        public static PanelSettingData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PanelSettingData();
                }
                return _instance;
            }
        }
        
        #endregion


        public ReactiveProperty<float> volumn = new ReactiveProperty<float>(1);
        public ReactiveProperty<bool> isOn = new ReactiveProperty<bool>(true);
        

    }
    
    public partial class PanelSetting : QFramework.UIPanel
    {
        
        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            switch (eventId)
            {
                case (int)UIEventEnum.Main.CloseSetting:
                    CloseSelf();
                    break;
                
                case (int)UIEventEnum.Main.ExitGame:
                    Debug.Log("退出游戏");
                    Application.Quit();
                    break;
                
                
            }
        }
        
        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as PanelSettingData ?? new PanelSettingData();
            // please add init code here
            PanelSettingData.Instance.isOn.Subscribe(_ =>
            {
                AudioKit.Settings.IsOn.Value = PanelSettingData.Instance.isOn.Value;
            });
            PanelSettingData.Instance.volumn.Subscribe(_ =>
            {
                AudioKit.Settings.MusicVolume.Value = PanelSettingData.Instance.volumn.Value;
                AudioKit.Settings.SoundVolume.Value = PanelSettingData.Instance.volumn.Value;
                AudioKit.Settings.VoiceVolume.Value = PanelSettingData.Instance.volumn.Value;
            });
            
            
            RegisterEvent(UIEventEnum.Main.CloseSetting);
            RegisterEvent(UIEventEnum.Main.ExitGame);


            
            BtnClose.onClick.AddListener(() =>
            {
                SendEvent(UIEventEnum.Main.CloseSetting);
            });
            BtnExit.onClick.AddListener(() =>
            {
                SendEvent(UIEventEnum.Main.ExitGame);
            });
            
            ToggleMusic.onValueChanged.AddListener(value =>
            {
                PanelSettingData.Instance.isOn.Value = value;
            });
            SldVolumn.onValueChanged.AddListener(value =>
            {
                PanelSettingData.Instance.volumn.Value = value;
            });
        }
        
        protected override void OnOpen(QFramework.IUIData uiData)
        {
            ToggleMusic.isOn = PanelSettingData.Instance.isOn.Value;
            SldVolumn.value = PanelSettingData.Instance.volumn.Value;
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