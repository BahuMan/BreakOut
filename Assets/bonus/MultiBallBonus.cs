using System;
using System.Collections;
using UnityEngine;

public class MultiBallBonus: MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleControl p = collision.gameObject.GetComponent<PaddleControl>();
        if (p != null)
        {
            Debug.Log("Multiball overriding whatToDo");
            BallControl ball = FindObjectOfType<BallControl>();
            BallControl extraBall = Instantiate<BallControl>(ball);
            extraBall.Launch(p.transform.position + transform.up, transform.up, 85f, 0.5f);
        }
    }
}

