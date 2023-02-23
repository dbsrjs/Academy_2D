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

    [SerializeField] private List<Image> lifes;
    [SerializeField] private List<Image> booms;

    [SerializeField] private GameObject popup;

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
        Time.timeScale = 1;
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void OnFireBoom()
    {
        Player p = FindAnyObjectByType<Player>();
        if(p.boom >= 0)
        {
            Instantiate(pd);
            BoomChange(--p.boom);
        }
    }

    public void LifeChange(int life)
    {
        foreach (var item in lifes)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < life; i++)
        {
            lifes[i].gameObject.SetActive(true);
        }
    }

    public void BoomChange(int boom)
    {
        foreach (var item in booms)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < boom; i++)
        {
            booms[i].gameObject.SetActive(true);
        }
    }

    public void Popup(bool show)
    {
        popup.SetActive(show);
    }

    public void OnYes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OnNo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
