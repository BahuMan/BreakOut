using System;
using System.Collections;
using UnityEngine;

public class MultiBallBonus: MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<BonusControl>().whatToDo += CreateMultiBall;
    }

    private void OnDisable()
    {
        GetComponent<BonusControl>().whatToDo -= CreateMultiBall;
    }

    private IEnumerable CreateMultiBall(PaddleControl p)
    {
        BallControl ball = FindObjectOfType<BallControl>();
        BallControl extraBall = Instantiate<BallControl>(ball);
        extraBall.Launch(p.transform.position + transform.up, transform.up, 45f, 0.5f);
        return null;
    }
}

