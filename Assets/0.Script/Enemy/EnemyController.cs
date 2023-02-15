using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Enemy[] enemies;

    float delaySpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delaySpawn += Time.deltaTime;
        if (delaySpawn > 4f)
        {
            int rand = Random.Range(0, enemies.Length);
            Enemy enemy = Instantiate(enemies[rand], transform);
            enemy.transform.localPosition = new Vector2(Random.Range(-2.5f, 2.5f), 0f);
            enemy.transform.SetParent(parent);

            delaySpawn = 0f;
        }
    }
}
