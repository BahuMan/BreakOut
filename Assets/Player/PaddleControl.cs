using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0f);
    }
}
