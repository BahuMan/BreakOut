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

    /**
     * Note to self:
     * Since the paddle exist of multiple colliders, this bonus may get multiple
     * OnCollisionEnter2D calls even though the bonus object is destroyed
     * the very next frame.
     * The custom component should take that into account.
     * (e.g. don't blindly create an extra ball in OnCollisionEnter2D)
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
