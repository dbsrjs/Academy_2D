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
        hpSlider.value = hpSlider.maxValue = 100;   //벨류값을 맥스(100)으로 변경
        mpSlider.value = hpSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))    //Z키를 누르면 피가 랜덤(5~20)으로 깍인다.
        {
            hpSlider.value -= Random.Range(5, 20);
        }
        
        if (Input.GetKeyDown(KeyCode.X))    //X키를 누르면 마나가 랜덤(5~20)으로 깍인다.
        {
            mpSlider.value -= Random.Range(5, 20);
        }

        if (time > 2)   //2초에 한번씩 랜덤(5~20)으로 피/마나를 올린다
        {
            hpSlider.value += Random.Range(5, 20);
            mpSlider.value += Random.Range(5, 20);
            time = 0;
        }
    }
}
