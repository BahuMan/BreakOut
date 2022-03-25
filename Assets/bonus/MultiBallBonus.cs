using System;
using System.Collections;
using UnityEngine;

public class MultiBallBonus: MonoBehaviour
{
    [SerializeField] BallControl normalBall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleControl p = collision.gameObject.GetComponent<PaddleControl>();
        if (p != null)
        {
            BallControl extraBall = Instantiate<BallControl>(normalBall);
            extraBall.Launch(p.transform.position + transform.up, transform.up, 85f, 0.5f);
        }
    }
}

