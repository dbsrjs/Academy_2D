using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] ButtomTs;
    [SerializeField] private Transform[] MiddleTs;
    [SerializeField] private Transform[] TopTs;

    [SerializeField] private float buttomSpeed = 0f;
    [SerializeField] private float middleSpeed = 0f;
    [SerializeField] private float topSpeed = 0f;

    [SerializeField] private float LastPos = 0f;
    [SerializeField] private float InitPos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in ButtomTs)
        {
            BGmove(item, buttomSpeed);
        }

        foreach (var item in MiddleTs)
        {
            BGmove(item, middleSpeed);
        }

        foreach (var item in TopTs)
        {
            BGmove(item, topSpeed);
        }
    }

    void BGmove(Transform trans, float speed)
    {
        trans.Translate(new Vector2(0f, -(Time.deltaTime * speed)));

        if (trans.position.y < LastPos)
        {
            trans.position = new Vector3(0, InitPos);
        }
    }
}
