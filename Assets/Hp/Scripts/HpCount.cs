using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCount : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider mpSlider;


    float time;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider.value = hpSlider.maxValue = 100;   //�������� �ƽ�(100)���� ����
        mpSlider.value = hpSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))    //ZŰ�� ������ �ǰ� ����(5~20)���� ���δ�.
        {
            hpSlider.value -= Random.Range(5, 20);
        }
        
        if (Input.GetKeyDown(KeyCode.X))    //XŰ�� ������ ������ ����(5~20)���� ���δ�.
        {
            mpSlider.value -= Random.Range(5, 20);
        }

        if (time > 2)   //2�ʿ� �ѹ��� ����(5~20)���� ��/������ �ø���
        {
            hpSlider.value += Random.Range(5, 20);
            mpSlider.value += Random.Range(5, 20);
            time = 0;
        }
    }
}
