using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMine : MonoBehaviour
{
    [SerializeField] private Image mineImage;
    [SerializeField] private TMPro.TMP_Text numText;
    [SerializeField] private Image panel;
    public void Init(int val)
    {
        if (val == -1)
        {
            mineImage.gameObject.SetActive(true);
            numText.gameObject.SetActive(false);
        }
        else
        {
            mineImage.gameObject.SetActive(false);
            numText.gameObject.SetActive(true);
            numText.text = val.ToString();
        }
    }
    public void OnPanelOpen()
    {
        panel.gameObject.SetActive(false);
    }
}
