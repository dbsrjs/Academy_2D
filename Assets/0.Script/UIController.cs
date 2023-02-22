using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private TMP_Text scoreTxt;

    [SerializeField] PlayerBoom pd;

    [SerializeField] private List<Image> srs;

    int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreTxt.text = score.ToString();
        }
    }

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void OnFireBoom()
    {
        Instantiate(pd);
    }

    public void LifeChange(int life)
    {
        foreach (var item in srs)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < life; i++)
        {
            srs[i].gameObject.SetActive(true);
        }
    }
}
