using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Weapon,
    Armor,
    Etc
}

public struct ItemData
{
    public ItemType type;
    public string spriteName;
    public int lv;
    public int upradeLv;
}

public class ItemStruct : MonoBehaviour
{

}
