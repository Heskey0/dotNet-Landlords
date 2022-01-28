using System;
using QFramework;
using UnityEngine;

public class SingletonPoolBase<TPool,T>:Pool<T> where TPool:new()
{
    #region Singleton

    private TPool _instance;

    public TPool Instance
    {
        get
        {
            if (_instance ==null)
                _instance = new TPool();
            return _instance;
        }
    }
    

    #endregion

    public override bool Recycle(T obj)
    {
        mCacheStack.Push(obj);
        return true;
    }
}