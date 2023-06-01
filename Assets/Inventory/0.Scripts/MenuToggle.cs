using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] ScrollRect[] view;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        if (toggles[0].isOn == true)
        {
            
        }
    }
}
