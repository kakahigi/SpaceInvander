using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingEnemy : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject ExplosionEffect;

    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        InvokeRepeating("Shoot", 0.5f, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        GameSceneManager.Score++;  //�X�R�A���Z�����s
        Destroy(this.gameObject);
    }

    void Shoot()
    {
        if(player != null)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
            bulletRigid.AddForce(new Vector2(0f, -200f));
            Vector2 target = player.transform.position - this.transform.position;  //target�Ƃ����ϐ��i�e�𔭎˂���ׂ������̃x�N�g�������j��������
            bulletRigid.velocity = target; //bulletRigid�̑��x�ɑ�����邱�ƂŔ���
            bulletRigid.velocity /= 2f; //���̂܂܂��ƒe����������̂ő��x�𔼕��ɕύX
        }
       
    }
}

