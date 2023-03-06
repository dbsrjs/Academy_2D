using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetirs : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    
    public int BlockXcnt { get; set; }
    public int BlockYcnt { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        BlockXcnt = 10;
        BlockYcnt = 20;
        CreateBGBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBGBlock()
    {
        for (int i = 0; i < BlockXcnt * BlockYcnt; i++)
        {
            Instantiate(prefab, parent);
        }
    }
}
