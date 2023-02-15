using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : Enemy
{
    public override void Init()
    {
        ed.speed = 1f;
        ed.hp = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
