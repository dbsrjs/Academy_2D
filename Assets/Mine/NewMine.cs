using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMine : MonoBehaviour
{
    [SerializeField] private Image mineImage;
    [SerializeField] private TMPro.TMP_Text numText;
    [SerializeField] private Image panel;

    int val, x, y;

    public void Init(int val, int x, int y)
    {
        this.val = val;
        this.x = x;
        this.y = y;

        switch(val)
        {
            case -1:
                mineImage.gameObject.SetActive(true);
                numText.gameObject.SetActive(false);
                break;
            case 0:
                mineImage.gameObject.SetActive(false);
                numText.gameObject.SetActive(true);
                numText.text = string.Empty;
                break;
            default:
                mineImage.gameObject.SetActive(false);
                numText.gameObject.SetActive(true);
                numText.text = val.ToString();
                break;
        }      
    }
    public void OnPanelOpen()
    {
        GetComponent<Button>().interactable = false;
        panel.gameObject.SetActive(false);
        if (val == 0)
            FindObjectOfType<MineCont>().AutoPoen(x, y);
        else if (val == -1)
            FindObjectOfType<MineCont>().ShowOverPanel();

        FindObjectOfType<MineCont>().ShowClearPanel1();
    }

    public void Open()
    {
        panel.gameObject.SetActive(false);
    }
}
