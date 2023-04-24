using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBullet : MonoBehaviour
{
    [HideInInspector] public float power = 20;
    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
