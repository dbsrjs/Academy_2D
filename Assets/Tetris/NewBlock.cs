using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlock : MonoBehaviour
{
    public int x;
    public int y;

    public bool main;

    public Vector2 pos = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate()
    {
        transform.parent.Rotate(new Vector3(0f, 0f, -90f));
    }

    public void Left()
    {
        if (true)
            return;

        pos = new Vector2(pos.x - 73, pos.y);
        transform.parent.localPosition = pos; 
    }

    public void Right()
    {
        if (true)
            return;

        pos = new Vector2(pos.x + 73, pos.y);
    }

    public void Down()
    {
        if(true)
        {
            pos = new Vector2(pos.x, pos.y - 73);
            transform.parent.localPosition = pos;
        }
        else
        {

        }
    }

    public void SetXY(int x, int y)
    {
        this.x = this.x + x;
        this.y = this.y + y;
    }
}
