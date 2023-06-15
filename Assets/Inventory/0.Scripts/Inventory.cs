using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item_Inventory item;
    [SerializeField] private Transform parent;
    [SerializeField] private TMP_Text inventoryCountTxt;

    int itemCount = 0;
    List<Item_Inventory> items = new List<Item_Inventory>();

    Dictionary<string, List<string>> dicItemNames = new Dictionary<string, List<string>>();

    public int ItemCount
    {
        get { return itemCount; }
        set
        {
            itemCount = value;
            inventoryCountTxt.text = $"{itemCount} / {invenMaxCount}";
        }
    }

    int invenMaxCount = 10;    //������ �̹����� �ִ� ����

    // Start is called before the first frame update
    void Start()
    {
        string[] keys = { $"{IconType.Armor}", $"{IconType.Helmet}", $"{IconType.Boots}" };
        string[] paths = {
            $"{Define.iconBasePath}/{IconType.Armor}",
            $"{Define.iconBasePath}/{IconType.Helmet}",
            $"{Define.iconBasePath}/{IconType.Boots}"
        };

        foreach (var key in keys)
        {
            if (!dicItemNames.ContainsKey(key))
            {
                dicItemNames.Add(key, new List<string>());
            }
        }

        int KeyCnt = 0;
        foreach (var path in paths)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(path);
            foreach (var item in sprites)
            {
                dicItemNames[keys[KeyCnt]].Add(item.name);
            }
            KeyCnt++;
        }

        for (int i = 0; i < invenMaxCount; i++)     //����� invenMaxCount(10)�� ����
        {
            items.Add(Instantiate(item, parent));
        }
        itemCount = 0;
    }
    int creatIdx = 0;

    enum Type
    {
        Armor, Helmet, Boots
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))   //������ ����
        {
            ItemData id = new ItemData();
            id.idx = creatIdx;
            id.lv = Random.Range(1, 100);   //���� ����
            id.upradeLv = Random.Range(1, 31);  //���� ��ȭ ����

            id.type = (Type)Random.Range(0, (int)Type.Boots + 1);
            string key = id.type.ToString();
            id.spriteName = dicItemNames[key][Random.Range(0, dicItemNames[key].Count)];

            creatIdx++;
            foreach (var item in items)
            {
                if(item.data  == null)
                {
                    item.SetData(id, () => ItemCount-- ).SetUI();
                    ItemCount++;
                    break;
                }
            }
        }
    }

    public void OnItemSort()  //���� ��ư
    {
        /*
        List<Item_Inventory> tempItems = items.ToList();
        tempItems.Sort((a, b) => a.data.idx.CompareTo(b.data.idx));

        //������ ������ ��ü
        for (int i = 0; i < tempItems.Count; i++)
        {
            items[i].data = tempItems[i].data;
        }

        for (int i = 0; i < invenMaxCount; i++)
        {
            if (items[i].data != null)
                items[i].SetData(item.data).SetUI();
        }
        */
    }
}