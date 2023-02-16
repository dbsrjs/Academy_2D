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
    public Transform fireTrans;
    public EnemyBullet eBullet;

    public List<Sprite> exprosionSprite;
    public List<Sprite> noramlSprite;
    public Sprite hitSprite;

    protected private Player player;
    public Transform parent;

    public abstract void Init();
    
    public virtual void Move()
    {
        if(ed.hp > 0)
        transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
    }

    float testTime = 0;
    void Update()
    {
        Move();

        if (player != null)
        {
            Vector2 vec = fireTrans.position - player.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            fireTrans.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        testTime += Time.deltaTime;
        if (testTime > 2f)
        {
            EnemyBullet bullet = Instantiate(eBullet, fireTrans);
            bullet.transform.SetParent(parent);
            testTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);

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
