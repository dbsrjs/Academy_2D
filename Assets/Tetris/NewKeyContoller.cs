using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKeyContoller : MonoBehaviour
{
    [HideInInspector] public GameObject block;

    float keyMoveDelay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyMoveDelay += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ContManger.instance.blockCont.FindBlockMain().Rotate();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ContManger.instance.blockCont.FindBlockMain().Left();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ContManger.instance.blockCont.FindBlockMain().Right();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ContManger.instance.blockCont.FindBlockMain().Down();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
