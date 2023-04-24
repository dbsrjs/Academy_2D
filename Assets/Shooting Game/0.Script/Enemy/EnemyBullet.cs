using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -(Time.deltaTime * speed)));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
