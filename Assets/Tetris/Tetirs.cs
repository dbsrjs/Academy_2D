using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetirs : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject target;
    
    public int BlockXcnt { get; set; }
    public int BlockYcnt { get; set; }

    private Vector3 startPos;
    private List<GameObject> blocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        BlockXcnt = 10;
        BlockYcnt = 20;

        GetComponent<GridLayoutGroup>().constraintCount = BlockXcnt;

        CreateBGBlock();
    }

    public void CreateBGBlock()
    {
        for (int i = 0; i < BlockXcnt * BlockYcnt; i++)
        {
            Instantiate(prefab, parent);
        }
        StartCoroutine(GridOff());
    }

    IEnumerator GridOff()
    {
        yield return new WaitForSeconds(0.02f);
        GetComponent<GridLayoutGroup>().enabled = false;
        startPos = blocks[BlockXcnt / 2].transform.localPosition;
        target.transform.localPosition = startPos;
    }

    private void BlockStop()
    {
        if (true)
        {

        }
    }
}