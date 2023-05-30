using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invent_Button : MonoBehaviour
{
    [SerializeField] GameObject enterButton;
    [SerializeField] GameObject panel;

    private bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false); //���� �� �� �ǳ� ������ ����.
        enterButton.SetActive(true);    //���� �� �� ��ư ������ ����.
    }

    public void OnEnterClick()
    {
        if (state == true)  //��ư�� ���ְ� �ǳ� ����.
        {
            enterButton.SetActive(false);
            panel.SetActive(true);
            state = false;
        }
    }
    
    public void OnExitClick()
    {
        if (state == false)  //��ư�� ���ְ� �ǳ� ����.
        {
            enterButton.SetActive(true);
            panel.SetActive(false);
            state = true;
        }
    }
}
