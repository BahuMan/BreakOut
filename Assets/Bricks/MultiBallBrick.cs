using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBallBrick : MonoBehaviour
{
    [SerializeField]
    BrickControl thisBrick;

    private void OnEnable()
    {
        thisBrick.BrickDestroyed += brick_destroyed;
    }

    private void OnDisable()
    {
        thisBrick.BrickDestroyed -= brick_destroyed;
    }

    private void brick_destroyed(BrickControl b)
    {
        BallControl ball = FindObjectOfType<BallControl>();
        BallControl extraBall = Instantiate<BallControl>(ball);
        extraBall.Launch(ball.transform.position, ball.transform.forward, 90f, 0.5f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
