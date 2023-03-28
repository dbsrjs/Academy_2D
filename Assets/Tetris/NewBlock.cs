using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlock : MonoBehaviour
{
    public int x;
    public int y;

    public bool main;

    public Vector2 pos = new Vector2();

    NewBGCont bgCont;
    NewBlockCont blockCont;

    void Start()
    {
        bgCont = ContManger.instance.bgCont;
        blockCont = ContManger.instance.blockCont;
    }

    void Update()
    {
        SetAutoXY(transform);
    }

    public void SetXY(int x, int y)
    {
        this.x = this.x + x;
        this.y = this.y + y;
    }


    public void SetAutoXY(Transform trans)
    {
        float distance = 100;
        for (int i = 0; i < bgCont.BlockYcnt; i++)
        {
            for (int j = 0; j < bgCont.BlockXcnt; j++)
            {
                float dis = Vector2.Distance(bgCont.bgBlock[i][j].transform.position, trans.position);
                if (dis < 0.001f)
                {
                    distance = dis;
                    BGBlock bgB = bgCont.bgBlock[i][j].GetComponent<BGBlock>();
                    x = bgB.X;
                    y = bgB.Y;
                    return;

                }
            }
        }
    }
    public void Rotate()
    {
        transform.parent.Rotate(new Vector3(0f, 0f, -90f));
    }

    public void Left()
    {
        if(isMoveX(-1))
        {
            pos = new Vector2(pos.x - 73, pos.y);
            transform.parent.localPosition = pos;
        }
     }

    public void Right()
    {
        if(isMoveX(1))
        {
            pos = new Vector2(pos.x + 73, pos.y);
            transform.parent.localPosition = pos;
        }
    }

    public void Down()
    {
        if (isMoveY())
        {
            pos = new Vector2(pos.x, pos.y - 73);
            transform.parent.localPosition = pos;
        }        
    }
    bool isMoveX(int val)
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            NewBlock b = transform.parent.GetChild(i).GetComponent<NewBlock>();
            int x = b.x + val;
            if (x >= 0 && x <= bgCont.BlockXcnt - 1)
                count++;
        }

        return count == transform.parent.childCount ? true : false;   ///count가 4면 true 아니면 false
    }

    bool isMoveY()
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            NewBlock b = transform.parent.GetChild(i).GetComponent<NewBlock>();
            if (b.y + 1 <= bgCont.BlockYcnt - 1)
                count++;
        }

        return count == transform.parent.childCount ? true : false;
    }
}
