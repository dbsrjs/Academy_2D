using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBGCont : MonoBehaviour
{
    [SerializeField] private BGBlock prefab;
    [SerializeField] private Transform parent;

    [HideInInspector] public Vector3 startPos;

    public List<List<BGBlock>> bgBlock = new List<List<BGBlock>>();
    public int BlockXcnt { get; set; }
    public int BlockYcnt { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        BlockXcnt = 10;
        BlockYcnt = 20;

        parent.GetComponent<GridLayoutGroup>().constraintCount = BlockXcnt;
        CreateBGBlock();
    }

    void CreateBGBlock()
    {
        for (int i = 0; i < BlockYcnt; i++)
        {
            bgBlock.Add(new List<BGBlock>());
            for (int j = 0; j < BlockXcnt; j++)
            {
                bgBlock[i].Add(Instantiate(prefab, parent));
                bgBlock[i][j].Check = false;
                bgBlock[i][j].Y = i;
                bgBlock[i][j].X = j;
            }
        }
        StartCoroutine(GridOff());
    }
    IEnumerator GridOff()
    {
        yield return new WaitForSeconds(0.02f);
        parent.GetComponent<GridLayoutGroup>().enabled = false;

        ContManger.instance.blockCont.CreateBlock();
    }
}
