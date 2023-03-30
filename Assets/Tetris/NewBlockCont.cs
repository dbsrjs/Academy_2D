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

    public void SetParent()
    {
        for (int i = createObj.transform.childCount -1; i >= 0 ; i--)
        {
            Transform t = createObj.transform.GetChild(i);
            t.SetParent(finishB);
            t.localRotation = Quaternion.Euler(Vector3.zero);

            fininshBlocks.Add(t.GetComponent<NewBlock>());
        }

        Destroy(createObj);
    }

    public void XLineDelete()
    {
        List<int> delIndexs = new List<int>();

        for (int i = bgCont.BlockYcnt -1; i >= 0; i--)
        {
            if(LineCheck(i))
            {
                delIndexs.Add(i);
            }
        }

        foreach (int y in delIndexs)
        {
            LineDelete(y);
        }

        delIndexs.Reverse();
        foreach (int y in delIndexs)
        {
            LineDown(y);
        }

        foreach (var item in delIndexs)
        {
            Debug.Log("Del : " + item);
        }
    }

    bool LineCheck(int y)
    {
        for (int x = 0; x < bgCont.BlockXcnt; x++)
        {
            if (bgCont.bgBlock[y][x].Check == false)
                return false;
        }
        return true;
    }

    void LineDelete(int y)
    {
        for (int i = fininshBlocks.Count -1; i >= 0; i--)
        {
            NewBlock b = fininshBlocks[i];
            if(b.y == y)
            {
                bgCont.bgBlock[b.y][b.x].Check = false;
                Destroy(b.gameObject);
                fininshBlocks.Remove(b);
            }
        }
    }

    void LineDown(int y)
    {
        for (int i = 0; i < fininshBlocks.Count; i++)
        {
            NewBlock b = fininshBlocks[i];
            if(b.y <= y - 1)
            {
                Vector2 vec2 = b.transform.localPosition;
                b.transform.localPosition = new Vector2(vec2.x, vec2.y - 73);
                b.y++;
            }
        }
        MapReflish();
    }

    void MapReflish()
    {
        for (int y = 0; y < bgCont.BlockYcnt; y++)
        {
            for (int x = 0; x < bgCont.BlockXcnt; x++)
            {
                bgCont.bgBlock[y][x].Check = false;
            }
        }

        for (int i = 0; i < fininshBlocks.Count; i++)
        {
            NewBlock b = fininshBlocks[i];
            bgCont.bgBlock[b.y][b.x].Check = true;
        }
    }
}
