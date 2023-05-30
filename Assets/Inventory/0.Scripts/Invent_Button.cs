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
        panel.SetActive(false); //실행 할 때 판넬 노출을 꺼줌.
        enterButton.SetActive(true);    //실행 할 때 버튼 노출을 켜줌.
    }

    public void OnEnterClick()
    {
        if (state == true)  //버튼을 없애고 판넬 노출.
        {
            enterButton.SetActive(false);
            panel.SetActive(true);
            state = false;
        }
    }
    
    public void OnExitClick()
    {
        if (state == false)  //버튼을 없애고 판넬 노출.
        {
            enterButton.SetActive(true);
            panel.SetActive(false);
            state = true;
        }
    }
}
