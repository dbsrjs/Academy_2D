using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int height = 5, width = 5;
    public GameObject image;
    private GameObject[,] blockMap;

    // Start is called before the first frame update
    void Start()
    {
        blockMap = new GameObject[width, height];
        
        IniatializeBlock();
    }
    void IniatializeBlock()
    {
        int startX = -width / 2;
        int startY = -height / 2;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 pos = new Vector3(startX + j, startY + i, 0);
                GameObject tmp = Instantiate<GameObject>(image, pos, Quaternion.identity);
                tmp.name = (i * 100 + j).ToString(); 

                blockMap[j, i] = tmp;
            }
        }
    }
}
