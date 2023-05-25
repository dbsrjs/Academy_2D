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
            "�뷱Ÿ��", "�������", "���ͱ���", "��������", "������Ʈ", "���ٶ��", "���ֺ���", "�������",
            "������", "��������", "�������", "�������", "������", "��Ŀ��", "��纣��", "����",
            "����", "��׵�Ʈ", "��Һ���", "�������", "��Ÿ����", "���ۺ���", "��������", "�����Ӹ�",
            "��������", "���߻���", "��������", "����ؿ�", "���̾�", "������", "��ŭ��Ģ", "���޴���",
            "���߻���", "�������", "��������", "�Ż��Ӵ�", "����Ʈ��", "���ɽ���", "��Ÿ����", "��Ÿ�ϸ�",
            "��ŸƮ��", "������ũ", "��ȥ����", "�̼�����", "�Ʊ��ڱ�", "�Ʊ��Ҵ�", "�Ƶ鹹��", "�Ʒմٷ�",
            "�Ƹ��Ƹ�", "�Ƹ�����", "���̵��", "��������", "���İ�Ƽ", "���̸���", "��������", "����Ʈ��",
            "���̽�Ƽ", "�˷ϴ޷�", "�˹�õ��", "�˽��޽�", "�������", "�ִ�Ÿ��", "�����", "����ƽ",
            "��������", "������ũ", "��Ƽ��Ż", "������ī", "��ħ�̽�", "���ϸ���", "�ҳ�ô�", "��������",
            "��ī�þ�", "��������", "��������", "�ýò���", "������ī", "���ݼ���", "��Ž���", "�ýú��",
            "�Ǽ�����", "��������", "���ݵ���", "���õ���", "��������", "�������", "���ǽ���", "�ø�����",
            "�˱��б�", "�˾˿˾�", "��������", "����ڷ�", "�丮����", "�������", "�����ä", "���۳��",
            "�ŵ�����", "�ȼ�����", "�������", "��������",
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
            OnEndChatting(randomNickmanes[Random.Range(0, randomNickmanes.Length)], "�ƹ��ų�");
        }
    }

    public void OnEndChatting(string nick, string txt)
    {
        if (string.IsNullOrEmpty(txt))    //inputField�� �� ���̸� return
            return;
        GameObject obj = Instantiate(items[0], parent);
        obj.GetComponent<TMP_Text>().text = $"[<color=red>{nick}</color>] : {txt}";
        inputField.text = string.Empty;
        inputField.Select();
    }
}
