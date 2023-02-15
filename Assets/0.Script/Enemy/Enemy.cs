using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Enemydata
{
    public float speed;
    public float hp;
}

public abstract class Enemy : MonoBehaviour
{
    public Enemydata ed = new Enemydata();
    public List<Sprite> exprosionSprite;
    public List<Sprite> noramlSprite;
    public Sprite hitSprite;

    public abstract void Init();
    
    public virtual void Move()
    {
        if(ed.hp > 0)
        transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            ed.hp -= collision.gameObject.GetComponent<PlayerBullet>().power;

            if (ed.hp <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteAnimation>().SetSprite(exprosionSprite, 0.05f, Die);
            }

            else
            {
                GetComponent<SpriteAnimation>().SetSprite(hitSprite, noramlSprite, 0.1f);
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
