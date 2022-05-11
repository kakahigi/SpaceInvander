using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //これがないとUI系の実装はできません

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] Text UIText;
    [SerializeField] Button HomeBtn;
    int timer = 3; //タイマーです。初期値は3
    [SerializeField] List<GameObject> EnemyPortList = new List<GameObject>();
    public static int Score = 0;  //あとで他のスクリプトからアクセスするので修飾子は必ずpublicにしてください
    AudioSource BulletSE;
    void Start()
    {
        BulletSE = GetComponent<AudioSource>();
        Invoke("DecreaseTimer", 1); // 3 -> 2 に変更 
        Invoke("DecreaseTimer", 2); //2 -> 1 に変更
        Invoke("CallStart", 3); //GameStart!と表示
    }

    void DecreaseTimer() //timerの数字を1だけ減らしてUIに表示する
    {
        timer -= 1;
        UIText.text = timer.ToString();
    }

    void CallStart() //GameStart!と表示
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
    public void AddScoreToText() //他のスクリプトからアクセスするからpublicで！
    {
        UIText.text = "Score: " + Score.ToString();  //テキストにスコアを代入
        UIText.gameObject.SetActive(true);  //テキストをアクティブにする
        HomeBtn.gameObject.SetActive(true);
    }
}