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

        }
    }
}
