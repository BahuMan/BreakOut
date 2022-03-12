using UnityEngine;

public class LaunchFirstBall : MonoBehaviour
{

    [SerializeField]
    BallControl firstBall;

    // Start is called before the first frame update
    void Start()
    {
        InitialLaunch();
    }

    [ContextMenu("Launch")]
    public void InitialLaunch()
    {
        BallControl ball = Instantiate<BallControl>(firstBall);
        ball.Launch(transform.position, transform.forward, 45f, 2f);
    }

}
