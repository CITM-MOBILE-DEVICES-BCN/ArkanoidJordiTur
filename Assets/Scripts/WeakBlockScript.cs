using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBlockScript : BlockScript
{
    void Start()
    {
        resistance = 3;
        points = 100;
    }

    protected override void DestroyBlock()
    {
        Debug.Log("Weak block destroyed");
        base.DestroyBlock();
    }
}
