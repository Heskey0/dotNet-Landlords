using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class GameMgr : Singleton<GameMgr>
{
    private GameObject _gameRoot;

    private GameMgr() { }

    public void Init()
    {
        QMsgCenter.Instance.ForwardMsg = ForwardMsgCallback;
        if (_gameRoot == null)
        {
            _gameRoot = new GameObject("GameRoot");
            _gameRoot.DontDestroyOnLoad().AddComponent<NetMgr>();
            _gameRoot.AddComponent<PlayerManager>();
        }
    }

    
    
    void ForwardMsgCallback(QMsg msg)
    {
        switch (msg.ManagerID)
        {
            case QMgrID.Network:
                NetMgr.Instance.SendMsg(msg);
                break;
            
            case QMgrID.Game:
                PlayerManager.Instance.SendMsg(msg);
                break;
            
            default:
                break;
        }
    }
}