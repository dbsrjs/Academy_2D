using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Item
{
    public override void Get()
    {
    }
    public override void Init()
    {
        speed = 0.5f;
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
