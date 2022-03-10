using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody2D _rigid;
    [SerializeField]
    Transform EdgeLeft;
    [SerializeField]
    Transform EdgeRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal") * speed;
        if (this.transform.position.x <= EdgeLeft.position.x && hor < 0f)
        {
            hor = 0f;
        }
        else if (this.transform.position.x >= EdgeRight.position.x && hor > 0f)
        {
            hor = 0f;
        }
        _rigid.velocity = new Vector2(hor, 0f);
    }
}
