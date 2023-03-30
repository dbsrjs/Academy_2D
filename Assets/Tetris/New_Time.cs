using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class New_Time : MonoBehaviour
{
    public TMP_Text timeText;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString();
    }
}
