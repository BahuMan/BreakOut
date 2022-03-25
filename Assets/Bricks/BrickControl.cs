using UnityEngine;

public class BrickControl : MonoBehaviour
{

    [SerializeField] BonusControl DropBonus;

    public delegate void BrickHitHandler(BrickControl b);
    public BrickHitHandler BrickHit;
    public BrickHitHandler BrickDestroyed;
    private BrickSound bounceSound;

    private void OnValidate()
    {
        if (DropBonus != null)
        {
            this.gameObject.name = "Brick with " + DropBonus.gameObject.name;
            this.GetComponent<SpriteRenderer>().color = DropBonus.GetBrickColor();
        }
        else
        {
            this.gameObject.name = "Brick";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bounceSound = FindObjectOfType<BrickSound>();
        Counting.Instance.addBrick(this);

        if (DropBonus != null)
        {
            GameObject go = new GameObject();
            go.name = DropBonus.gameObject.name;
            go.transform.parent = this.transform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = DropBonus.GetBrickImage();
            sr.sortingLayerName = "SpecialBrick";
        }
    }

    [ContextMenu("RandomColor")]
    public void RandomColor()
    {
        this.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, .8f, 1f, .8f, 1f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        bounceSound.PlayBrick(Random.Range(0, 9));
        Counting.Instance.removeBrick(this);
        BrickHit?.Invoke(this);
        BrickDestroyed?.Invoke(this);

        if (DropBonus != null)
        {
            BonusControl bonus = Instantiate<BonusControl>(DropBonus);
            bonus.transform.position = transform.position;
        }
        Destroy(this.gameObject);
    }
}
