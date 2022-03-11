using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneControl : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallControl ball = collision.gameObject.GetComponent<BallControl>();
        if (ball is null) return;

    }
}
