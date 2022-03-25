using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPadControl : MonoBehaviour
{
    private const float STICKY_DURATION = 30f;
    private const float GLUE_DURATION = 2f;
    private float StickyEndTime; //when the pad will return to normal
    private struct Glue
    {
        public float releaseTime;
        public BallControl ball;
    }

    private List<Glue> stuck;

    private void Start()
    {
        stuck = new List<Glue>(4);

        foreach (var r in this.GetComponentsInChildren<SpriteRenderer>())
        {
            r.color = Color.blue;
        }
        StickyEndTime = Time.time + STICKY_DURATION;
    }

    public void AdditionalStickyTime()
    {
        StickyEndTime += STICKY_DURATION;
    }

    private void Update()
    {

        while (stuck.Count > 0 && stuck[0].releaseTime < Time.time)
        {
            ReleaseBall(0);
        }
        if (Time.time> StickyEndTime)
        {

            while (stuck.Count > 0)
            {
                ReleaseBall(0);
            }

            foreach (var r in this.GetComponentsInChildren<SpriteRenderer>())
            {
                r.color = Color.white;
            }
            Destroy(this);
        }
    }

    private void GlueBall(BallControl b)
    {
        Rigidbody2D rigidBall = b.gameObject.GetComponent<Rigidbody2D>();
        rigidBall.isKinematic = true;
        //rigidBall.velocity = Vector3.zero;
        b.transform.SetParent(this.transform);
        stuck.Add(new Glue { releaseTime = Time.time + GLUE_DURATION, ball = b });
    }

    private void ReleaseBall(int i)
    {
        if (stuck[i].ball != null)
        {
            Rigidbody2D rigidBall = stuck[i].ball.GetComponent<Rigidbody2D>();
            rigidBall.isKinematic = false;
            stuck[i].ball.transform.SetParent(null);

        }
        stuck.RemoveAt(i);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallControl b = collision.gameObject.GetComponent<BallControl>();
        if (b != null)
        {
            GlueBall(b);
        }
    }

}
