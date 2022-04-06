using System;
using System.Collections;
using UnityEngine;

public class MultiBallBonus: MonoBehaviour
{
    [SerializeField] BallControl normalBall;

    //workaround to avoid a second trigger:
    private bool ExtraBallWasLaunched = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //workaround to avoid a second trigger:
        if (ExtraBallWasLaunched) return;

        PaddleControl p = collision.gameObject.GetComponent<PaddleControl>();
        if (p != null)
        {
            BallControl extraBall = Instantiate<BallControl>(normalBall);
            extraBall.Launch(p.transform.position + transform.up, transform.up, 85f, 0.5f);

            //to avoid a second trigger (because pad has multiple colliders)
            ExtraBallWasLaunched = true;
        }
    }
}

