using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min : MonoBehaviour
{   
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject screen;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonUp(0))
        {   
            Debug.Log(gameObject.name);
        }
    }
}