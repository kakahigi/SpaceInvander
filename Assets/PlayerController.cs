using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    [SerializeField] GameObject bullet; //����Œe���X�N���v�g�ŊǗ��ł���悤�ɂȂ�����
    [SerializeField] GameObject ExplosionEffect; //�����G�t�F�N�g�̃v���n�u�i�G�f�B�^��ő������̂�Y�ꂸ�Ɂj
    AudioSource BulletSE;
    [SerializeField] GameSceneManager mygameManager; //�g�����ꂽSerializeField��GameSceneManager����
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 0.5f);
        BulletSE = GetComponent<AudioSource>();
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, 200f));
        BulletSE.Play(); //����炷�ɂ�Play�֐����Ăׂ�OK�I
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        mygameManager.AddScoreToText();  //����֐����Ăяo�����
        Destroy(this.gameObject); //�������g�̃I�u�W�F�N�g������
    }
}
