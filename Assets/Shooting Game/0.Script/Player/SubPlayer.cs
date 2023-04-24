using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayer : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private FollowBullet bullet;
    float bulletTime = 3;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }
    public void show()
    {
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            time += Time.deltaTime;
            if(time > bulletTime)
            {
                Instantiate(bullet, transform).transform.SetParent(parent);

                time = 0;
            }
        }
    }
}
