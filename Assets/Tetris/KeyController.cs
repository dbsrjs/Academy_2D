using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject block;

    float moveX = 0;
    float moveY = 0;

    float autoDownTime = 0;
    // Start is called before the first frame update
    void Start()  
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            block.transform.Rotate(Vector3.forward * 90 * -1);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveX -= 73f;
            block.transform.localPosition = new Vector3(moveX, moveY);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveX += 73f;
            block.transform.localPosition = new Vector3(moveX, moveY);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BlockDown();
            autoDownTime = 0;
        }

        autoDownTime += Time.deltaTime;
        if (autoDownTime > 0.8f)
        {
            autoDownTime = 0;
            BlockDown();
        }
    }

    void BlockDown()
    {
        moveY -= 73f;
        block.transform.localPosition = new Vector3(moveX, moveY);
    }
}
