using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Transform parent;
    [SerializeField] private TMP_Text inventoryCountTxt;

    int itemCount = 0;
    List<Item> items = new List<Item>();

    public int ItemCount
    {
        get { return itemCount; }
        set
        {
            itemCount = value;
            inventoryCountTxt.text = $"{itemCount} / {invenMaxCount}";
        }
    }

    int invenMaxCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < invenMaxCount; i++)
        {
            items.Add(Instantiate(item, parent));
        }
        itemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ItemData id = new ItemData();
            id.lv = Random.Range(1, 100);
            id.upradeLv = Random.Range(1, 31);
        }
    }
}
