using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBGCont : MonoBehaviour
{
    [SerializeField] private BGBlock prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private AudioSource t_Audio;

    [HideInInspector] public Vector3 startPos;

    public List<List<BGBlock>> bgBlock = new List<List<BGBlock>>();
    const int startYIndex = 1;
    public int BlockXcnt { get; set; }
    public int BlockYcnt { get; set; }

    public float spacingX = 0;

    public float spacingY = 0;
    // Start is called before the first frame update
    void Start()
    {
        BlockXcnt = 10;
        BlockYcnt = 20;

        parent.GetComponent<GridLayoutGroup>().constraintCount = BlockXcnt;

        spacingX = parent.GetComponent<GridLayoutGroup>().constraintCount = BlockXcnt;
        spacingY = parent.GetComponent<GridLayoutGroup>().constraintCount = BlockYcnt;
        CreateBGBlock();
    }

    void CreateBGBlock()
    {
        for (int i = 0; i < BlockYcnt; i++)
        {
            bgBlock.Add(new List<BGBlock>());
            for (int j = 0; j < BlockXcnt; j++)
            {
                bgBlock[i].Add(Instantiate(prefab, parent));
                bgBlock[i][j].Check = false;
                bgBlock[i][j].Y = i;
                bgBlock[i][j].X = j;
            }
        }
        StartCoroutine(GridOff());
    }
    IEnumerator GridOff()
    {
        yield return new WaitForSeconds(0.02f);
        parent.GetComponent<GridLayoutGroup>().enabled = false;

        ContManger.instance.blockCont.CreateBlock();
    }

    public void EffectSoundStart()
    {
        t_Audio.Play();
    }
}
