using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBlockScript : BlockScript
{
    void Start()
    {
        resistance = 4;
        points = 300;
    }

    protected override void DestroyBlock()
    {
        Debug.Log("Strong block destroyed");
        base.DestroyBlock();
    }
}
