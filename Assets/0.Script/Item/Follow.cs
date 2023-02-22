using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Item
{
    public override void Get()
    {
      
    }
    public override void Init()
    {
        speed = 1f;
        base.Init();
    }
    // Update is called once per frame
    void Start()
    {
        Init();
    }
}
