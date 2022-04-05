using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPadControl : MonoBehaviour
{
    private const float STICKY_DURATION = 10f;
    private const float GLUE_DURATION = 2f;
    private float StickyEndTime; //when the pad will return to normal
    private struct Glue
    {
        public float releaseTime;
        public BallControl ball;
        public Vector2 lastVelocity;
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

    private void FixedUpdate()
    {

        if (Input.GetButtonDown("Fire2")) Debug.Break();
        if (Input.GetButtonDown("Fire3")) Debug.Break();

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
        
        //probably because of multiple colliders, glueball sometimes
        //triggers multiple times. When the ball has already been glued, do nothing
        if (rigidBall.isKinematic) return; 

        rigidBall.isKinematic = true;
        //rigidBall.velocity = Vector3.zero;
        b.transform.SetParent(this.transform);
        b.GetComponent<SpriteRenderer>().color = Color.green;
        stuck.Add(new Glue { releaseTime = Time.time + GLUE_DURATION, ball = b, lastVelocity = rigidBall.velocity });
        rigidBall.velocity = Vector2.zero;
    }

    private void ReleaseBall(int i)
    {
        if (stuck[i].ball != null)
        {
            stuck[i].ball.transform.SetParent(null);
            stuck[i].ball.GetComponent<SpriteRenderer>().color = Color.white;
            stuck[i].ball.GetComponent<Rigidbody2D>().isKinematic = false;
            stuck[i].ball.GetComponent<Rigidbody2D>().velocity = stuck[i].lastVelocity;
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
