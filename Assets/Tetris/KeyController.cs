using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject block;

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
            block.transform.localPosition -= new Vector3(73, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            block.transform.localPosition += new Vector3(73, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BlockDown();
            autoDownTime = 0;
        }

        autoDownTime += Time.deltaTime;
        if (autoDownTime > 0.8f) ///자동 줄 내림
        {
            autoDownTime = 0;
            BlockDown();
        }
    }
    void BlockDown()
    {
        block.transform.localPosition -= new Vector3(0, 73, 0);
    }

    void BlockStop()
    {
        if (true)
        {

        }
    }
}