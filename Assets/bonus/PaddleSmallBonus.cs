using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSmallBonus : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleControl p = collision.gameObject.GetComponent<PaddleControl>();
        if (p != null)
        {
            Vector3 scale = collision.transform.localScale;
            collision.transform.localScale = new Vector3(scale.x - .2f, 1f, 1f);
        }
    }
}
