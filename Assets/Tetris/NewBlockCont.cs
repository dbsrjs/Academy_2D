using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlockCont : MonoBehaviour
{
    [SerializeField] List<GameObject> blocks;
    [SerializeField] Transform parent;
    [SerializeField] Transform finishB;
    const int startPosY = 1;

    GameObject createObj;

    public List<NewBlock> fininshBlocks = new List<NewBlock>();

    NewBGCont bgCont;
    // Start is called before the first frame update
    void Start()
    {
        bgCont = ContManger.instance.bgCont;
    }

    public void CreateBlock()
    {
        int rand = Random.Range(0, blocks.Count);
        int x = ContManger.instance.bgCont.BlockXcnt / 2;

        createObj = Instantiate(blocks[rand], parent);
        createObj.transform.localPosition = ContManger.instance.bgCont.bgBlock[startPosY][x].transform.localPosition;

        ContManger.instance.keyCont.block = createObj;

        NewBlock b = FindBlockMain();
        b.pos = createObj.transform.localPosition;
    }

    public NewBlock FindBlockMain()
    {
        for (int i = 0; i < createObj.transform.childCount; i++)
        {
            NewBlock b = createObj.transform.GetChild(i).GetComponent<NewBlock>();
            if (b.main)
                return b;
        }
        return null;
    }
}
