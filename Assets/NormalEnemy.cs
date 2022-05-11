using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject ExplosionEffect;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        InvokeRepeating("Shoot", 0f, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        GameSceneManager.Score++;  //スコア加算を実行
        Destroy(this.gameObject);
    }
    void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, -200f));
    }
}
