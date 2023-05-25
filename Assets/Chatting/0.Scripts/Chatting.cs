using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chatting : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform parent;

    [SerializeField] private TMP_InputField inputField;

    string myNickname = "Unity";
    string[] randomNickmanes;

    float randomChattingTimer = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        randomNickmanes = new string[]
        {
            "밸런타인", "버블버블", "버터구이", "베르나르", "벨제비트", "별바라기", "별주부전", "보드게임",
            "보라돌이", "붉은노을", "붉은루비", "붉은장미", "블랙베리", "블랙커피", "블루베리", "블루블랙",
            "블링블링", "비네딕트", "비닐봉투", "비빔국수", "비타민제", "빙글빙글", "빨간구두", "빨간머리",
            "빨간모자", "빵긋빵굿", "빵빠레빵", "사랑해요", "사이언스", "살랑살랑", "상큼발칙", "새콤달콤",
            "생긋생긋", "서든어택", "스나이퍼", "신사임당", "스마트폰", "스믈스믈", "스타워즈", "스타일링",
            "스타트업", "스테이크", "신혼여행", "싱숭생숭", "아기자기", "아기팬더", "아들뭐해", "아롱다롱",
            "아름아름", "아리따움", "아이디어", "선덕여왕", "스파게티", "아이리스", "성형미인", "스펙트럼",
            "아이스티", "알록달록", "알바천국", "알쏭달쏭", "알콩달콩", "애니타임", "어벤져스", "어쿠스틱",
            "엄지공주", "에이핑크", "센티멘탈", "스포츠카", "아침이슬", "에일리언", "소녀시대", "슬림라인",
            "아카시아", "여유만발", "소주한잔", "시시껄렁", "아프리카", "연금술사", "소탐대실", "시시비비",
            "악세서리", "연지곤지", "예쁨둥이", "오늘도난", "오락가락", "오토바이", "오피스텔", "올망졸망",
            "옹긋쫑긋", "옹알옹알", "와이파이", "요로코롬", "요리조리", "요술램프", "요술부채", "슈퍼노바",
            "신데렐라", "안성탕면", "영어사전", "요조숙녀",
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnEndChatting(myNickname, inputField.text);
        }

        randomChattingTimer += Time.deltaTime;
        if (randomChattingTimer > 0.5f)
        {
            randomChattingTimer = 0;
            OnEndChatting(randomNickmanes[Random.Range(0, randomNickmanes.Length)], "아무거나");
        }
    }

    public void OnEndChatting(string nick, string txt)
    {
        if (string.IsNullOrEmpty(txt))    //inputField가 빈 값이면 return
            return;
        GameObject obj = Instantiate(items[0], parent);
        obj.GetComponent<TMP_Text>().text = $"[<color=red>{nick}</color>] : {txt}";
        inputField.text = string.Empty;
        inputField.Select();
    }
}
