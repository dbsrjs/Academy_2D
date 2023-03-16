using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject block;

    float moveX = 0;
    float autoDownTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            block.transform.Rotate(Vector3.forward * 90 * -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 vec = new Vector2(-73, 0);
            block.transform.Translate(vec);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 vec = new Vector2(73, 0);
            block.transform.Translate(vec);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BlockDown();
            autoDownTime = 0;
        }

        //autoDownTime += Time.deltaTime;
        //if (autoDownTime > 0.8f) ///자동 줄 내림
        //{
        //    autoDownTime = 0;
        //    BlockDown();
        //}
    }
    void BlockDown()
    {
        Vector2 vec = new Vector2(0, -73);
        transform.Translate(vec);
    }

    void BlockStop()    ///-693.5
    {
        Vector2 vec = new Vector2(0, -693.5f);
        if (true)
        {
            
        }
    }

}
