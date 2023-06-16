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
    [SerializeField] private Transform content;    //GameObject

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

    int invenMaxCount = 10;    //아이템 이미지의 최대 개수

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

        for (int i = 0; i < invenMaxCount; i++)     //배경을 invenMaxCount(10)개 생성
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
        if (Input.GetKeyDown(KeyCode.F1))   //아이템 생성
        {
            ItemData id = new ItemData();
            id.idx = creatIdx;
            id.lv = Random.Range(1, 100);   //랜덤 레벨
            id.upgradeLv = Random.Range(1, 31);  //랜덤 강화 레벨

            Type t = (Type)Random.Range(0, (int)Type.Boots + 1);
            id.type = (IconType)System.Enum.Parse(typeof(IconType), t.ToString());

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

    public void OnItemSort()  //정렬 버튼
    {
        items.Sort
        (
            delegate (Item_Inventory a1, Item_Inventory a2)
            {
                if (a1.data.type != a2.data.type)
                {
                    return a2.data.type.CompareTo(a1.data.type);
                }
                return a1.data.lv.CompareTo(a2.data.lv);
            }
        );

        List<ItemData> dataList = new List<ItemData>();
        foreach (var item in items)
        {
            ItemData id = new ItemData();
            id.idx = item.data.idx;
            id.lv = item.data.lv;
            id.spriteName = item.data.spriteName;
            id.type = item.data.type;
            id.upgradeLv = item.data.upgradeLv;
            dataList.Add(id);
        }

        for (int i = 0; i < content.childCount; i++)
        {
            ItemData id = dataList[i];
            content.GetChild(i).GetComponent<Item_Inventory>().SetData(id, () => ItemCount--).SetUI();
        }
    }
}