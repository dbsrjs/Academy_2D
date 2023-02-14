using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float speed = 3.8f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * speed));        
    }
}
