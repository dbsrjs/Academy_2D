using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item_Inventory item;
    [SerializeField] private Transform parent;
    [SerializeField] private TMP_Text inventoryCountTxt;

    int itemCount = 0;
    List<Item_Inventory> items = new List<Item_Inventory>();

    List<string> itemeNames = new List<string>();

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
        string path = $"{Define.iconBasePath}/{IconType.Armor}/";
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (var item in sprites)
        {
            itemeNames.Add(item.name);
        }

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
            id.lv = Random.Range(1, 100);   //랜덤 레벨
            id.upradeLv = Random.Range(1, 31);  //강화 레벨
            id.spriteName = itemeNames[Random.Range(0, itemeNames.Count)];
            id.type = IconType.Armor;

            foreach (var item in items)
            {
                if(item.data  == null)
                {
                    item.SetData(id, SetItemCount).SetUI();
                    ItemCount++;
                    break;
                }
            }
        }
    }

    void SetItemCount()
    {
        ItemCount--;
    }
}