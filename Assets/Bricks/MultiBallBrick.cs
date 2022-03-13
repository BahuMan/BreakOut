using UnityEngine;

public class MultiBallBrick : MonoBehaviour
{
    [SerializeField]
    BrickControl thisBrick;

    [SerializeField]
    BonusControl bonusDrop;

    private void OnEnable()
    {
        thisBrick.BrickDestroyed += brick_destroyed;
    }

    private void OnDisable()
    {
        thisBrick.BrickDestroyed -= brick_destroyed;
    }

    private void brick_destroyed(BrickControl b)
    {

        BonusControl newBonus = Instantiate<BonusControl>(bonusDrop);
        newBonus.transform.position = this.transform.position;
        newBonus.gameObject.AddComponent<MultiBallBonus>();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
