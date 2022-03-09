using UnityEngine;
using System.Collections.Generic;

public class Counting : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text scoreLabel;

    private List<BrickControl> bricksInLevel;
    private int score;

    public delegate void LevelFinishedHandler();
    public LevelFinishedHandler OnLevelFinished;

    // Start is called before the first frame update
    void Start()
    {
        BrickControl[] bricks = FindObjectsOfType<BrickControl>();
        Debug.Log("bricks found: " + bricks.Length);
        bricksInLevel = new List<BrickControl>(bricks);
        foreach (BrickControl b in bricksInLevel)
        {
            b.BrickDestroyed += BrickDestroyedHandler;
        }
        score = 0;
        scoreLabel.text = "" + score;
    }

    private void BrickDestroyedHandler(BrickControl b)
    {
        bricksInLevel.Remove(b);
        score += 1;
        scoreLabel.text = "" + score;


    }
}
