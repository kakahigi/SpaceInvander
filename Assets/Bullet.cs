using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float ActiveTime = 2f;

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
        Destroy(this.gameObject); //�������g�̃I�u�W�F�N�g������
    }
}
