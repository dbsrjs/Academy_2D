using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBlock : MonoBehaviour
{
    public bool Check { get; set; }

    public int X;
    public int Y;

    public TMPro.TMP_Text text;

    [SerializeField] bool isUICheck = true;

    void Update()
    {
        if (isUICheck)
            text.text = Check == true ? "O" : "X";
        else
            text.text = "";   
    }
}
