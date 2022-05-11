using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float ActiveTime = 10f;

    void Start()
    {
        Invoke("DestroyMyself", ActiveTime);
    }

    void DestroyMyself()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }
}
