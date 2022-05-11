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
        InvokeRepeating("GenerateEnemy", 0f, 5f); //GenerateEnemy�֐���4�b�Ɉ�x�Ăяo����
        //Invoke("DestroyEnemy", ActiveTime);
    }

    //���̓G�𐶐�����^�C�~���O�����肷��֐�
    void SetNextEnemy()   //�����_���Ȏ��Ԍ��GenerateEnemy���Ăяo��
    {
        float interval = Random.Range(0f, 2f);  //0~3�b�̃����_���Ȏ��Ԃ�interval�ƒu��
        Invoke("GenerateEnemy", interval);  //interval���Ԍ��GenerateEnemy���Ăяo��
    }

    //�G�𐶐�����֐�
    void GenerateEnemy()
    {
        //GameObject enemy = Instantiate(NormalEnemy);  //�G�𐶐�
        int enemyindex = Random.Range(0, 3);  //�ϐ�enemyindex��0~2�̃����_���Ȑ���������i�͈͂�0�ȏ�3�����j
        GameObject enemy = Instantiate(EnemyList[enemyindex]);  //�G�𐶐�
        enemy.transform.position = this.transform.position; //���������G�̈ʒu���A����EnemyPort�̈ʒu�ɒ���
        SetNextEnemy();
    }

    //void DestroyEnemy()
    //{
    //    Destroy(this.gameObject);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(this.gameObject); //�������g�̃I�u�W�F�N�g������
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
