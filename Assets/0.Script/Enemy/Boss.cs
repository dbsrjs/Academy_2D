using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override void Init()
    {
        ed.speed = 1f;
        ed.hp = 2000f;
        ed.isBoss = true;
        ed.fireNormalTime = 0.5f;
        player = FindObjectOfType<Player>();

        GetComponent<SpriteAnimation>().SetSprite(noramlSprite, 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
