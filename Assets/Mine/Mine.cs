using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(transform.name);
        }

        ImageOpen();

    }

    private void ImageOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screen.SetActive(false);
        }
    }
}