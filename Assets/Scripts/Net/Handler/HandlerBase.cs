using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandlerBase
{
    public abstract void OnReceive(int subCode, object value);
    
}
