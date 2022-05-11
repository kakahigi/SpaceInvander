using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //���ꂪ�Ȃ���UI�n�̎����͂ł��܂���

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] Text UIText;
    [SerializeField] Button HomeBtn;
    int timer = 3; //�^�C�}�[�ł��B�����l��3
    [SerializeField] List<GameObject> EnemyPortList = new List<GameObject>();
    public static int Score = 0;  //���Ƃő��̃X�N���v�g����A�N�Z�X����̂ŏC���q�͕K��public�ɂ��Ă�������
    AudioSource BulletSE;
    void Start()
    {
        BulletSE = GetComponent<AudioSource>();
        Invoke("DecreaseTimer", 1); // 3 -> 2 �ɕύX 
        Invoke("DecreaseTimer", 2); //2 -> 1 �ɕύX
        Invoke("CallStart", 3); //GameStart!�ƕ\��
    }

    void DecreaseTimer() //timer�̐�����1�������炵��UI�ɕ\������
    {
        timer -= 1;
        UIText.text = timer.ToString();
    }

    void CallStart() //GameStart!�ƕ\��
    {
        UIText.text = "GameStart!!";
        Invoke("DeactiveText", 1);
        for (int i = 0; i < EnemyPortList.Count; i++)
        {
            EnemyPortList[i].SetActive(true);
        }
    }
    void DeactiveText()
    {
        UIText.gameObject.SetActive(false);
    }
    public void AddScoreToText() //���̃X�N���v�g����A�N�Z�X���邩��public�ŁI
    {
        UIText.text = "Score: " + Score.ToString();  //�e�L�X�g�ɃX�R�A����
        UIText.gameObject.SetActive(true);  //�e�L�X�g���A�N�e�B�u�ɂ���
        HomeBtn.gameObject.SetActive(true);
    }
}