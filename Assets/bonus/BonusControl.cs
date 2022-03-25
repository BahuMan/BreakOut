using System.Collections;
using UnityEngine;

public class BonusControl : MonoBehaviour
{
    [SerializeField]
    float fallSpeed = 2f;
    [SerializeField]
    Sprite BrickImage;
    [SerializeField]
    Color BrickColor;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = -this.transform.up * fallSpeed;
    }

    public Sprite GetBrickImage()
    {
        return BrickImage;
    }

    public Color GetBrickColor()
    {
        return BrickColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Basic BonusControl destroys the Object");
        Destroy(this.gameObject);
    }

}
