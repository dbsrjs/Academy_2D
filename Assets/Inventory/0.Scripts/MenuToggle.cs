using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] GameObject[] view;


    [SerializeField] Image[] allImg;   //전체
    [SerializeField] Image[] equipmentImg;    //장비
    [SerializeField] Image[] foodImg;   //음식
    [SerializeField] Image[] etcImg;   //기타

    [SerializeField] Button[] create; //생성

    [SerializeField] private Transform[] parent;
    [SerializeField] private GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        ViewOff();  //모든 스크롤뷰 끄기
    }

    public void OnEquipmentClick()     //버튼을 누를 때마다 장비의 토글 생성
    {
        Instantiate(prefab, parent[1]);
    }
    
    public void OnFoodClick()     //버튼을 누를 때마다 음식의 토글 생성
    {
        Instantiate(prefab, parent[2]);
    }
    
    public void OnEtcClick()     //버튼을 누를 때마다 기타의 토글 생성
    {
        Instantiate(prefab, parent[3]);
    }

    public void OffEquipmentClick()    //버튼을 누를 때마다 장비의 토글 삭제
    {
        
    }
    
    public void OffFoodClick()    //버튼을 누를 때마다 음식의 토글 삭제
    {
        
    }
    
    public void OffEtcClick()     //버튼을 누를 때마다 기타의 토글 삭제
    {
        
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
