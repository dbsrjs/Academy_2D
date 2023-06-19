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
    [SerializeField] private Transform content;

    int itemCount = 0;
    int invenMaxCount = 10;    //아이템 이미지의 최대 개수

    List<Item_Inventory> items = new List<Item_Inventory>();
    Dictionary<string, List<string>> dicItemNames = new Dictionary<string, List<string>>();

    public int ItemCount    //카운트 개수
    {
        get { return itemCount; }
        set
        {
            itemCount = value;
            inventoryCountTxt.text = $"{itemCount} / {invenMaxCount}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        List<string> paths = new List<string>();
        List<string> keys = new List<string>();
        IconType lastIndex = System.Enum.GetValues(typeof(IconType)).Cast<IconType>().Last();
        for (int i = 0; i <= (int)lastIndex; i++)
        {
            paths.Add($"{Define.iconBasePath} / {(IconType)i}");
            keys.Add(((IconType)i).ToString());
        }

        foreach (var key in keys)
        {
            if (!dicItemNames.ContainsKey(key))
            {
                dicItemNames.Add(key, new List<string>());
            }
        }

        for (int i = 0; i < paths.Count; i++)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(paths[i]);
            foreach (var item in sprites)
            {
                dicItemNames[keys[i]].Add(item.name);
            }
        }

        for (int i = 0; i < invenMaxCount; i++)     //배경을 invenMaxCount(10)개 생성
        {
            items.Add(Instantiate(item, parent));
        }
        itemCount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))   //아이템 생성
        {
            if (ItemCount >= invenMaxCount)
                return;

            ItemData id = new ItemData();
            id.lv = Random.Range(1, 100);   //랜덤 레벨
            id.upgradeLv = Random.Range(1, 31);  //랜덤 강화 레벨

            IconType lastIndex = System.Enum.GetValues(typeof(IconType)).Cast<IconType>().Last();

            string key = id.type.ToString();
            id.spriteName = dicItemNames[key][Random.Range(0, dicItemNames[key].Count)];

            foreach (var item in items)
            {
                if (item.data == null)
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
                if (a1.data != null && a2.data != null)
                {
                    if (a1.data.type != a2.data.type)
                    {
                        return a2.data.type.CompareTo(a1.data.type);
                    }
                    return a2.data.lv.CompareTo(a1.data.lv);
                }
                else
                {
                    return 0;
                }
            }
        );

        List<ItemData> dataList = new List<ItemData>();
        foreach (var item in items)
        {
            if (item.data != null)
            {
                ItemData id = new ItemData();
                id.idx = item.data.idx;
                id.lv = item.data.lv;
                id.spriteName = item.data.spriteName;
                id.type = item.data.type;
                id.upgradeLv = item.data.upgradeLv;
                dataList.Add(id);
            }
        }

        for (int i = 0; i < content.childCount; i++)
        {
            try
            {
                ItemData id = dataList[i];
                content.GetChild(i).GetComponent<Item_Inventory>().SetData(id, () => ItemCount--).SetUI();
            }
            catch (System.ArgumentOutOfRangeException e) {
                content.GetChild(i).GetComponent<Item_Inventory>().Empty();
            }
        }
    }

    public void InvenTabChange(int tabIndex)
    {
        IconType it = (IconType)tabIndex;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].data != null)
            {
                if (items[i].data.type != it)
                    items[i].Empty();
                else
                   items[i].SetUI();
            }
        }
    }

    public void OnInventoryAddCount()
    {
        int addCount = 10;
        for (int i = 0; i < addCount; i++)
        {
            Item_Inventory temp = Instantiate(item, parent);
            temp.name = i.ToString();
            items.Add(temp);
        }
        invenMaxCount += addCount;

        ItemCount = ItemCount;
    }
}