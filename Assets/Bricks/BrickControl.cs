using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, .8f, 1f, .8f, 1f);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
