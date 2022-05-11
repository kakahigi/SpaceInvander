using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    [SerializeField] GameObject bullet; //これで弾をスクリプトで管理できるようになったぜ
    [SerializeField] GameObject ExplosionEffect; //爆発エフェクトのプリハブ（エディタ上で代入するのを忘れずに）
    AudioSource BulletSE;
    [SerializeField] GameSceneManager mygameManager; //使い慣れたSerializeFieldでGameSceneManagerを代入
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
        BulletSE.Play(); //音を鳴らすにはPlay関数を呼べばOK！
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
        mygameManager.AddScoreToText();  //これ関数を呼び出せるよ
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }
}
