using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Inventory : MonoBehaviour
{
    [SerializeField] private Sprite[] gradeSprites;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text upgeadeLevel;

    ItemData data = new ItemData();

    void Start()
    {

    }
}
