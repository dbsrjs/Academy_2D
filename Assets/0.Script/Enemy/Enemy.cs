using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float fireNormalTime;
    public float speed;
    public float hp;
    public bool isBoss;
    public float rotZ;
    public int paIdx;
    public bool isRot;
    public int score;
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    public List<Transform> fireTrans;
    public EnemyBullet eBullet;

    public List<Sprite> explosionSprite;
    public List<Sprite> noramlSprite;
    public Sprite hitSprite;

    protected Transform parent;
    protected Player player;

   

    int fireIndex = 0;
    float fireTime = 0;

    public abstract void Init();

    public virtual void SetParent(Transform parent)
    {
        this.parent = parent;
    }

    public virtual void Move()
    {
        if (ed.isBoss)
        {
            if(transform.localPosition.y >= 3)
            {
                if (ed.hp > 0)
                    transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
            }
        }
        else
        {
            if (ed.hp > 0)
                transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
        }
    }

    
    void Update()
    {
        Move();

        ATTPatten();
    }

    
    private void ATTPatten()
    {
        fireTime += Time.deltaTime;
        switch(ed.paIdx)
        {
            case 0:

                Vector2 vec = fireTrans[fireIndex].position - player.transform.position;
                float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                fireTrans[fireIndex].rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                if (fireTime > ed.fireNormalTime)
                {
                    CreateBullet(fireTrans[fireIndex]);
                    if (Random.Range(0, 100) < 20)
                    {
                        PattenChange();
                    }
                    fireIndex++;
                    if (fireTrans.Count <= fireIndex)
                    {
                        fireIndex = 0;
                    }
                }
                break;
            case 1:
                if (fireTime > 0.2f)
                {
                    transform.GetChild(1).transform.rotation = Quaternion.Euler(0f, 0f, ed.rotZ);
                    ed.rotZ += 5f;

                    CreateBullet(transform.GetChild(1).transform);
                    if(ed.rotZ > 350)
                    {
                        PattenChange();
                    }
                }
                break;
            case 2:
                if (fireTime > 0.2f)
                {
                    if(ed.isRot)
                    {
                        if (ed.rotZ >= 60)
                        {
                            ed.isRot = false;
                            if (Random.Range(0, 100) < 20)
                            {
                                PattenChange();
                            }
                        }
                        ed.rotZ += 10f;
                    }
                    else
                    {
                        if(ed.rotZ <= -60)
                        {
                            ed.isRot = true;
                            if (Random.Range(0, 100) < 20)
                            {
                                PattenChange();
                            }
                        }
                        ed.rotZ -= 10f;
                    }
                    transform.GetChild(1).transform.rotation = Quaternion.Euler(0f, 0f, ed.rotZ);

                    CreateBullet(transform.GetChild(1).transform);
                }
                break;
        }
    }

    private void PattenChange()
    {
        if (!ed.isBoss)
        {
            ed.paIdx = 0;
            return;
        }
        ed.rotZ = 0;
        ed.isRot = false;
        ed.paIdx = Random.Range(0, 3);
    }

    private void CreateBullet(Transform trans)
    {
        EnemyBullet bullet = Instantiate(eBullet, trans);
        bullet.transform.SetParent(parent);
        fireTime = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBullet>() ||
            collision.gameObject.GetComponent<FollowBullet>() )
        {
            // 총알 데미지 처리
            float power = 0;       
            if(collision.gameObject.GetComponent<PlayerBullet>())
            {
                power = collision.gameObject.GetComponent<PlayerBullet>().power;
            }
            else if(collision.gameObject.GetComponent<FollowBullet>())
            {
                power = collision.gameObject.GetComponent<FollowBullet>().power;
            }
            ed.hp -= power;

            if (ed.hp <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteAnimation>().SetSprite(explosionSprite, 0.05f, Die);
            }
            else
            {
                GetComponent<SpriteAnimation>().SetSprite(hitSprite, noramlSprite, 0.1f);
            }
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        if (ed.isBoss)
        {
            EnemyController.Instance.StageUp();
        }
        ItemController.Instace.Spwan(transform);
        UIController.Instance.Score += ed.score;
        Destroy(gameObject);
    }
}
