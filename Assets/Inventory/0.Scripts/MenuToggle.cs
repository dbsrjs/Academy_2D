using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] GameObject[] view;

    [SerializeField] private Transform[] parent;
    [SerializeField] private GameObject prefab;

    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        ViewOff();  //모든 스크롤뷰 끄기

        while (i <= 25)     //전체
        {
            Instantiate(prefab, parent[0]);
            i++;
        }
        i = 1;

        while (i <= 13)     //장비
        {
            Instantiate(prefab, parent[1]);
            i++;
        }
        i = 1;

        while (i <= 4)      //음식
        {
            Instantiate(prefab, parent[2]);
            i++;
        }
        i = 1;

        while (i <= 8)      //기타
        {
            Instantiate(prefab, parent[3]);
            i++;
        }
        i = 1;
    }

    public void OnClick()   //나를 제외한 스크롤뷰 끄기
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
