using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControl : MonoBehaviour
{

    public delegate IEnumerable ActivateWhenHitByPaddle(PaddleControl p);

    [SerializeField]
    float fallSpeed = 2f;

    public ActivateWhenHitByPaddle whatToDo;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = -this.transform.up * fallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleControl p = collision.gameObject.GetComponent<PaddleControl>();
        if (p != null)
        {
            whatToDo(p);
            Destroy(this.gameObject);
        }
    }

}
