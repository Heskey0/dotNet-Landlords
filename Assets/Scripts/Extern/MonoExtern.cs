using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonoExtern
{

    public static TComponent Find<TComponent>(this GameObject parent,string path)where TComponent:class
    {
        var targetObj = parent.transform.Find(path);
        return targetObj?.GetComponent<TComponent>();
    }
}

