using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public static ItemController Instace;

    [SerializeField] private List<Item> items;
    [SerializeField] private Transform parent;

    void Awake()
    {
        Instace = this;
    }

    /// <summary>
    /// 아이템 드랍 0:폭탄 1:파워 2:코인3:보조
    /// <summary>
    public void Spwan(Transform trans = null)
    {
        int rand = Random.Range(0, 100);        
        int itemIndex = rand <= 75 ? 0 : rand <= 85 ? 1 : rand <= 95 ? 2 : 3;
        if (trans != null)
        {
            Item item = Instantiate(items[itemIndex], trans);
            item.transform.SetParent(parent);
        }
        else
        {
            Instantiate(items[itemIndex], parent);
        }
    }
}
