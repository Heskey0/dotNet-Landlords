#region Head
//https://space.bilibili.com/455965619
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using QFramework.Example;
using UnityEngine;

public class Setup : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1136,720,false);
        GameMgr.Instance.Init();
        ResKit.Init();
        UIKit.OpenPanel<PanelBg>(UILevel.Bg);
    }

    private void Func()
    {
        //this.Delay();
        this.ExecuteNode(new SequenceNode());
        var delay = DelayAction.Allocate(1, () =>
        {
            Debug.Log(11);
        });

        this.ExecuteNode(delay);


        var sequenceNode = new SequenceNode();
        sequenceNode.Append(DelayAction.Allocate(1, () =>
        {
            Debug.Log(DateTime.Now);
        }));
        this.ExecuteNode(sequenceNode);

        this.Sequence().Delay(1).Event().Delay(1).Event();
    }
}
