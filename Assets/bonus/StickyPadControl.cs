using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPadControl : MonoBehaviour
{
    private const float STICKY_DURATION = 30f;
    private float StickyEndTime;

    private void Start()
    {
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
        if (Time.time> StickyEndTime)
        {
            foreach (var r in this.GetComponentsInChildren<SpriteRenderer>())
            {
                r.color = Color.white;
            }
            Destroy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallControl b = collision.gameObject.GetComponent<BallControl>();
        if (b != null)
        {
            StartCoroutine(KeepBall(b));
        }
    }

    private IEnumerator KeepBall(BallControl b)
    {
        Rigidbody2D rigidBall = b.gameObject.GetComponent<Rigidbody2D>();
        rigidBall.isKinematic = true;
        b.transform.SetParent(this.transform);
        yield return new WaitForSeconds(2f);
        rigidBall.isKinematic = false;
        b.transform.SetParent(null);
    }
}
