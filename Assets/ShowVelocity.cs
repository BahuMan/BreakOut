using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowVelocity : MonoBehaviour
{

    [SerializeField]
    Text _velocityText;
    [SerializeField]
    Rigidbody2D _ball;

    // Update is called once per frame
    void FixedUpdate()
    {
        _velocityText.text = _ball.velocity.ToString();
    }
}
