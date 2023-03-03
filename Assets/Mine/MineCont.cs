using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MineCont : MonoBehaviour
{
    [SerializeField] private NewMine prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panel1;

    [SerializeField] private GridLayoutGroup grid;

    int[,] map;

    [SerializeField] private int size = 5;
    [SerializeField] private int mineCnt = 1;

    private List<List<NewMine>> mineList = new List<List<NewMine>>();
    void Start()
    {
        grid.constraintCount = size;

        map = new int[size, size];
        int[] tempMap = new int[size * size];
        for (int i = 0; i < mineCnt; i++) ///5*5 타일 생성
        {
            tempMap[i] = -1;
        }

        for (int i = 0; i < size; i++) ///지뢰 5개 랜덤 위치에 설치
        {
            tempMap = tempMap.OrderBy(x => Random.Range(0, i)).ToArray();
        }
        int count = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++, count++)
            {
                map[i, j] = tempMap[count];
            }
        }

        ///섞인 지뢰 찾기
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (map[i, j] == -1)
                {
                    FindMine(i, j);
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            mineList.Add(new List<NewMine>());
            for (int j = 0; j < size; j++)
            {
                NewMine m = Instantiate(prefab, parent);
                m.Init(map[i,j], i, j);
                //m.OnPanelOpen(); //모든 판넬 열기 (임시)
                mineList[i].Add(m);
            }
        }        
    }

    void FindMine(int x, int y) ///숫자 생성
    {
        for (int i = x -1; i <= x + 1; i++)
        {
            if (i < 0 || i >= size)
                continue;
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j >= size)
                    continue;
                if (map[i, j] == -1)
                    continue;                    

                map[i, j]++;   
            }
        }
    }

    public void AutoPoen(int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i >= size)
                continue;
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j >= size)
                    continue;

                if (i == x && j == y)
                    continue;

                if (map[i, j] == 0)
                {
                    mineList[i][j].Open();
                    clickCnt++;
                }
            }
        }
    }

    public void ShowOverPanel()
    {
        panel.SetActive(true);
    }
    int clickCnt = 0;

    public void ShowClearPanel1()
    {
        clickCnt++;
        int count = (size * size) - clickCnt;

        if (true)
        {

        }

    }
}
