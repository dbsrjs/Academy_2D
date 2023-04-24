using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private List<Sprite> boomSprites;

    float firstSize = 0;
    float sizeTime = 0;

    void Start()
    {
        AnimationStart();
    }

    void Update()
    {
        sizeTime += Time.deltaTime;
        if (sizeTime > 0.01f)
        {
            sizeTime = 0;
            firstSize += 0.02f;
            transform.localScale = new Vector2(firstSize, firstSize);
        }
    }

    void AnimationStart()
    {
        GetComponent<SpriteAnimation>().SetSprite(boomSprites, 0.4f, () => Destroy(gameObject));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Player>())
        {
            Destroy(collision.gameObject);
        }

        else if (!collision.GetComponent<Wall>())
        {
            Destroy(collision.gameObject);
        }
    }
}
