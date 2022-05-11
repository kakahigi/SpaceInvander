using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPort : MonoBehaviour
{
    [SerializeField] GameObject NormalEnemy;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    //[SerializeField] float ActiveTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemy", 0f, 5f); //GenerateEnemy関数を4秒に一度呼び出すよ
        //Invoke("DestroyEnemy", ActiveTime);
    }

    //次の敵を生成するタイミングを決定する関数
    void SetNextEnemy()   //ランダムな時間後にGenerateEnemyを呼び出す
    {
        float interval = Random.Range(0f, 2f);  //0~3秒のランダムな時間をintervalと置く
        Invoke("GenerateEnemy", interval);  //interval時間後にGenerateEnemyを呼び出す
    }

    //敵を生成する関数
    void GenerateEnemy()
    {
        //GameObject enemy = Instantiate(NormalEnemy);  //敵を生成
        int enemyindex = Random.Range(0, 3);  //変数enemyindexに0~2のランダムな数字を入れる（範囲は0以上3未満）
        GameObject enemy = Instantiate(EnemyList[enemyindex]);  //敵を生成
        enemy.transform.position = this.transform.position; //生成した敵の位置を、このEnemyPortの位置に調整
        SetNextEnemy();
    }

    //void DestroyEnemy()
    //{
    //    Destroy(this.gameObject);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(this.gameObject); //自分自身のオブジェクトを消去
    //}
    //[SerializeField] List<GameObject> EnemyPortList = new List<GameObject>();
    //[SerializeField] Text UIText;

    //void CallStart()
    //{
    //    UIText.text = "GameStart!!";
    //    Invoke("DeactiveText", 1);
    //    for (int i = 0; i < EnemyList.Count; i++)
    //    {
    //        EnemyList[i].SetActive(true);
    //    }
    //}

}
