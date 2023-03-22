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
        if (Input.GetKeyDown(KeyCode.UpArrow)) ///방향 바꾸기
        {
            block.transform.Rotate(Vector3.forward * 90 * -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) ///왼쪽으로 이동
        {
            if (block.transform.localPosition.x > -328.5f)
            {
                block.transform.localPosition -= new Vector3(73, 0, 0);
            }            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) ///오른쪽으로 이동
        {
            if (block.transform.localPosition.x < 328.5f)
            {
                block.transform.localPosition += new Vector3(73, 0, 0);
            }                
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) ///아래로 한칸 이동
        {                    
            BlockDown();
            autoDownTime = 0;            
        }
        else if (Input.GetKeyDown(KeyCode.Space)) ///한번에 내리기
        {

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
        if (block.transform.localPosition.y > -693.5f)
        {
            block.transform.localPosition -= new Vector3(0, 73, 0);
        }            
    }
}