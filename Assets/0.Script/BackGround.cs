using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] buttomTs;
    [SerializeField] private Transform[] middleTs;
    [SerializeField] private Transform[] topTs;

    [SerializeField] private float buttomSpeed = 0f;
    [SerializeField] private float middleSpeed = 0f;
    [SerializeField] private float topSpeed = 0f;

    [SerializeField] private float lastPos = 0f;
    [SerializeField] private float initPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in buttomTs)
        {
            BGMove(item, buttomSpeed);
        }

        foreach (var item in middleTs)
        {
            BGMove(item, middleSpeed);
        }

        foreach (var item in topTs)
        {
            BGMove(item, topSpeed);
        }
    }

    void BGMove(Transform trans, float speed)
    {
        trans.Translate(new Vector2(0f, -(Time.deltaTime * speed)));
        if (trans.position.y < lastPos)
        {
            trans.position = new Vector3(0, initPos);
        }
    }
}
