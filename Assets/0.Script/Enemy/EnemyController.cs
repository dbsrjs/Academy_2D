using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;
    [SerializeField] private Transform parent;
    [SerializeField] private Enemy[] enemies;

    [SerializeField] private Transform eBullet;

    float delaySpawn = 100f;
    float nextDelay = 2f;

    int stage = 1;
    int spawnCount = 0;
    bool spawnStop = false;

    void Awake()
    {
        Instance = this;
    }

    public int Stage { get; set; }
    public int SpawnCount { get; set; }
    public bool SpawnStop { get; set; }
    // Update is called once per frame
    void Update()
    {
        if (spawnStop)
            return;

        if (spawnCount != 0 && (spawnCount % (stage * 5)) == 0)
        {
            Enemy enemy = Instantiate(enemies[enemies.Length - 1], transform);

            enemy.SetParent(eBullet);
            enemy.transform.localPosition = Vector2.zero;
            enemy.transform.SetParent(parent);
            spawnStop = true;
        }
        else
        {
            delaySpawn += Time.deltaTime;
            if (delaySpawn > nextDelay)
            {
                int rand = Random.Range(0, stage);
                if (rand > enemies.Length - 1)
                    rand = enemies.Length - 2;
                Enemy enemy = Instantiate(enemies[rand], transform);
                enemy.SetParent(eBullet);
                enemy.transform.localPosition = new Vector2(Random.Range(-2.5f, 2.5f), 0f);
                enemy.transform.SetParent(parent);

                delaySpawn = 0f;
                spawnCount++;
                nextDelay = Random.Range(2, 5);
            }
        }
    }
    public void StageUp()
    {
        stage++;
        spawnCount = 0;
        spawnStop = false;
    }
}
