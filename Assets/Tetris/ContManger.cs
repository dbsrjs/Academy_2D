using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContManger : MonoBehaviour
{
    public static ContManger instance;

    public NewKeyContoller keyCont;
    public NewBGCont bgCont;
    public NewBlockCont blockCont;
    
        void Awake()
    {
        instance = this;
    }
}
