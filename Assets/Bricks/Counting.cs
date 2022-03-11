using UnityEngine;
using System.Collections.Generic;

public class Counting
{
    public delegate void ScoreChangedDelegate(int newScore);
    public ScoreChangedDelegate ScoreChangeHandler;
    private int score;

    public delegate void LivesChangedDelegate(int newLives);
    public LivesChangedDelegate LivesChangedHandler;
    private int lives;

    private List<BrickControl> bricksInLevel;

    public delegate void LevelFinishedHandler();
    public LevelFinishedHandler OnLevelFinished;

    private static Counting instance;

    public static Counting Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Counting(0, 3);
            }
            return instance;
        }
    }

    private Counting(int resetScore, int resetLives)
    {
        score = resetScore;
        lives = resetLives;

        bricksInLevel = new List<BrickControl>();
    }

    public void addBrick(BrickControl b)
    {
        bricksInLevel.Add(b);
    }

    public void removeBrick(BrickControl b)
    {
        bricksInLevel.Remove(b);
        score += 1;
        ScoreChangeHandler?.Invoke(Instance.score);

        if (bricksInLevel.Count == 0) OnLevelFinished?.Invoke();
    }

}
