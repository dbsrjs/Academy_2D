using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetirs : MonoBehaviour
{
    public KeyController kc;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    
    [SerializeField] private GameObject target;
    [SerializeField] private Transform blockParent;
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

        CreatBlock();
    }
    public void CreateBGBlock() ///백그라운드 생성
    {
        for (int i = 0; i < BlockXcnt * BlockYcnt; i++)
        {
            blocks.Add(Instantiate(prefab, parent));
        }
        StartCoroutine(GridOff());
    }

    public void CreatBlock() ///블럭 생성
    {
        GameObject obj = Instantiate(target, blockParent);
        kc.block = obj;

    }

    IEnumerator GridOff()
    {
        yield return new WaitForSeconds(0.02f);
        GetComponent<GridLayoutGroup>().enabled = false;
        startPos = blocks[BlockXcnt / 2].transform.localPosition;
        target.transform.localPosition = startPos;
    }
}
