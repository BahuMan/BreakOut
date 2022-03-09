using UnityEngine;

public class BrickControl : MonoBehaviour
{
    public delegate void BrickHitHandler(BrickControl b);
    public BrickHitHandler BrickHit;
    public BrickHitHandler BrickDestroyed;
    private BrickSound bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        bounceSound = FindObjectOfType<BrickSound>();
    }

    [ContextMenu("RandomColor")]
    public void RandomColor()
    {
        this.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, .8f, 1f, .8f, 1f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        bounceSound.PlayBrick(Random.Range(0, 9));
        BrickHit?.Invoke(this);
        BrickDestroyed?.Invoke(this);
        Destroy(this.gameObject);
    }
}
