using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] GameObject[] view;


    [SerializeField] Image[] allImg;   //��ü
    [SerializeField] Image[] equipmentImg;    //���
    [SerializeField] Image[] foodImg;   //����
    [SerializeField] Image[] etcImg;   //��Ÿ

    [SerializeField] Button[] create; //����

    [SerializeField] private Transform[] parent;
    [SerializeField] private GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        ViewOff();  //��� ��ũ�Ѻ� ����
    }

    public void OnEquipmentClick()     //��ư�� ���� ������ ����� ��� ����
    {
        Instantiate(prefab, parent[1]);
    }
    
    public void OnFoodClick()     //��ư�� ���� ������ ������ ��� ����
    {
        Instantiate(prefab, parent[2]);
    }
    
    public void OnEtcClick()     //��ư�� ���� ������ ��Ÿ�� ��� ����
    {
        Instantiate(prefab, parent[3]);
    }

    public void OffEquipmentClick()    //��ư�� ���� ������ ����� ��� ����
    {
        
    }
    
    public void OffFoodClick()    //��ư�� ���� ������ ������ ��� ����
    {
        
    }
    
    public void OffEtcClick()     //��ư�� ���� ������ ��Ÿ�� ��� ����
    {
        
    }



    public void OnClick()   //���� ������ ��ũ�Ѻ� ����
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

    private void ViewOff()  //��� �並 OFF ��Ű��
    {
        view[0].SetActive(false);
        view[1].SetActive(false);
        view[2].SetActive(false);
        view[3].SetActive(false);
    }
}
