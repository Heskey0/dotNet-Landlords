using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : Singleton<SceneMgr>
{
    private SceneMgr()
    {
        
    }
    
    public void Load(int index,Action onSceneLoaded)
    {
        SceneManager.sceneLoaded += (arg0, mode) =>
        {
            onSceneLoaded?.Invoke();
        };
        SceneManager.LoadScene(index);
    }
}
