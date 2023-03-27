using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Tetirs tetris;
    [HideInInspector] public GameObject block;

    float autoDownTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (block == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) ///���� �ٲٱ�
        {
            block.transform.Rotate(Vector3.forward * 90 * -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) ///�������� �̵�
        {
            if (block.transform.localPosition.x > -328.5f)
            {
                block.transform.localPosition -= new Vector3(73, 0, 0);
            }            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) ///���������� �̵�
        {
            if (block.transform.localPosition.x < 328.5f)
            {
                block.transform.localPosition += new Vector3(73, 0, 0);
            }                
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) ///�Ʒ��� ��ĭ �̵�
        {                    
            BlockDown();
            autoDownTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space)) ///�ѹ��� ������
        {
            for (int i = 0; block.transform.localPosition.y != -693.5f; i++)
            {
                BlockDown();
            }
            tetris.CreatBlock();
        }

        BlockDown_Auto();

        BlockPile();
    }

    void BlockDown_Auto()   ///�ڵ� �� ����
    {
        autoDownTime += Time.deltaTime;
        if (autoDownTime > 0.8f) 
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
        else
        {
            tetris.CreatBlock();
        }
    }

    void BlockPile() /// ��Ʈ���� �ױ�
    {

    }
}