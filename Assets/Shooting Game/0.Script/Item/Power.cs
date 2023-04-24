using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Item
{
    public override void Get()
    {

    }

    public override void Init()
    {
        speed = 2f;
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
