using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] public float speedScroll;

    void Update()
    {
        Scroll();

        if (transform.position.y <= -11f)
        {
            ResetPosition();
        }
    }

    void Scroll()
    {
        Vector3 pos = transform.position;
        float ScrollSpeed = speedScroll;
        pos.y -= ScrollSpeed;
        transform.position = pos;
    }

    void ResetPosition()
    {
        Vector3 pos = transform.position;
        pos.y += 30f;
        transform.position = pos;
    }
}
