using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneControl : MonoBehaviour
{

    [SerializeField]
    LaunchFirstBall restart;

    AudioSource LifeLossSound;

    private void Start()
    {
        LifeLossSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallControl ball = collision.gameObject.GetComponent<BallControl>();
        if (ball is null) return;

        Destroy(ball.gameObject);
        //if this was the last ball in play, subtract life and launch new, normal ball
        BallControl[] remaining = FindObjectsOfType<BallControl>();
        if (remaining.Length < 2)
        {
            LifeLossSound.Play();
            Counting.Instance.changeLife(-1);
            if (Counting.Instance.Lives > 0)
            {
                restart.InitialLaunch();
            }
        }
    }

}
