using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void Get()
    {
        UIController.Instance.Score += 10;
    }

    public override void Init()
    {
        speed = 3f;
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
