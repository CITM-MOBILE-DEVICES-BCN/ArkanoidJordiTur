using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBlockScript : BlockScript
{
    void Start()
    {
        resistance = 3;
        points = 50;
    }

    protected override void DestroyBlock()
    {
        Debug.Log("Mid block destroyed");
        base.DestroyBlock();
    }
}
