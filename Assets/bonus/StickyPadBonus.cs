using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPadBonus : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleControl p = collision.gameObject.GetComponent<PaddleControl>();
        if (p != null)
        {
            StickyPadControl sticky = p.GetComponent<StickyPadControl>();

            if (sticky == null)
            {
                p.gameObject.AddComponent<StickyPadControl>();
            }
            else
            {
                sticky.AdditionalStickyTime();
            }
        }
    }
}
