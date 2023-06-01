using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] Toggle[] gameToggles;
    [SerializeField] GameObject[] view;
    // Start is called before the first frame update
    void Start()
    {
        ViewOff();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (toggles[0].isOn == true)
        {
            ViewOff();
            view[0].SetActive(true);
        }

        else if (toggles[1].isOn == true)
        {
            ViewOff();
            view[1].SetActive(true);
        }
        
        else if (toggles[2].isOn == true)
        {
            ViewOff();
            view[2].SetActive(true);
        }
        
        else if (toggles[3].isOn == true)
        {
            ViewOff();
            view[3].SetActive(true);
        }
    }

    private void ViewOff()  //모든 뷰를 OFF 시키기
    {
        view[0].SetActive(false);
        view[1].SetActive(false);
        view[2].SetActive(false);
        view[3].SetActive(false);
    }
}
