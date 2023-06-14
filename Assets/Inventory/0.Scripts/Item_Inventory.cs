using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Item_Inventory : MonoBehaviour
{
    [SerializeField] private Sprite[] gradeSprites;

    [SerializeField] private Image frame;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text upgeadeLevel;

    [HideInInspector] public ItemData data = null;

    Sprite[] frameSprites;

    UnityAction action = null;

    void Start()
    {
        icon.gameObject.SetActive(false);
        icon.sprite = null;
        level.text = string.Empty;
        upgeadeLevel.text = string.Empty;

        frameSprites = Resources.LoadAll<Sprite>($"{Define.iconFramePath}/");
    }

    public Item_Inventory SetData(ItemData data, UnityAction action = null)
    {
        this.data = data;
        this.action = action;
        return this;
    }

    public Item_Inventory SetUI()
    {
        icon.gameObject.SetActive(true);
        string path = $"{Define.iconBasePath}/{data.type}/{data.spriteName}";

        level.text = $"Lv{data.lv}";
        upgeadeLevel.text = $"+{data.upradeLv}";
        icon.sprite = Resources.Load<Sprite>(path);

        for (int i = 0; i < frameSprites.Length; i++)   //레벨에 해당되는 프레임(배경) 생성
        {
            int lv = (i + 1) * 20;
            if(data.lv <= lv)
            {
                 frame.sprite = frameSprites[i + 1];
                 break;
            }
        }

        return this;
    }
    public void OnClick()
    {
        icon.gameObject.SetActive(false);
        level.text = string.Empty;
        upgeadeLevel.text = string.Empty;
        frame.sprite = frameSprites[0];

        action();
        action = null;
        
        data = null;
    }
}
