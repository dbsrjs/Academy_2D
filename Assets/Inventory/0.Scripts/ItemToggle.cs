using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToggle : MonoBehaviour
{
    enum Type
    {
        Armor, Helmet, Boots
    }

    [SerializeField] private Inventory inventory;
    private Toggle[] toggles;
    // Start is called before the first frame update
    void Start()
    {
        int count = transform.childCount;
        toggles = new Toggle[count];

        for (int i = 0; i < count; i++)
        {
            toggles[i] = transform.GetChild(i).GetComponent<Toggle>();  
        }
    }

    public void OnChoice(Toggle toggle)
    {
        int selectIdx = -1;
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn)
            {
                selectIdx = i;
                inventory.InvenTabChange(i);
                break;
            }
        }
    }
}
