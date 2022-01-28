#region Head
//https://space.bilibili.com/455965619
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class PlayerManager : QMgrBehaviour,ISingleton
{
    #region Singleton

    private PlayerManager() { }
    public void OnSingletonInit() { }
    public static PlayerManager Instance
    {
        get => MonoSingletonProperty<PlayerManager>.Instance;
    }
    
    #endregion

    public override int ManagerId
    {
        get => QMgrID.Game;
    }
    
}
