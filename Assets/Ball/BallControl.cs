using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D _rigid;

    [SerializeField]
    float speed;

    [SerializeField]
    float nudge; //if vertical velocity is below "nudge", we will push the ball a bit

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(resetPositie());
    }

    IEnumerator resetPositie()
    {
        //fixed start positie, random richting:
        this.transform.position = new Vector2(0, -3);
        _rigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(2f);

        this.transform.eulerAngles = Vector3.forward * Random.Range(-45f, 45f);
        _rigid.velocity = this.transform.up * speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rigid.velocity.y < nudge
            && _rigid.velocity.y > -nudge
            && _rigid.velocity.magnitude > speed/2f)
        {
            Debug.Log("Ball was horizontal, let's give it a nudge");
            _rigid.velocity = new Vector2(_rigid.velocity.x, -nudge);
        }
        if (_rigid.velocity.x < nudge
            && _rigid.velocity.x > -nudge
            && _rigid.velocity.magnitude > speed / 2f)
        {
            Debug.Log("Ball was vertical, let's give it a nudge");
            _rigid.velocity = new Vector2( (transform.position.x>0? -nudge:nudge), _rigid.velocity.y);
        }

        
        _rigid.velocity = speed * _rigid.velocity.normalized;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(resetPositie());
        }
    }
}
