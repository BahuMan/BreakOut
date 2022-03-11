using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        OnScoreChange(Counting.Instance.Score);
    }

    private void OnScoreChange(int newScore)
    {
        scoreText.text = "" + newScore;
    }

    private void OnEnable()
    {
        Counting.Instance.ScoreChangeHandler += OnScoreChange;
    }

    private void OnDisable()
    {
        Counting.Instance.ScoreChangeHandler -= OnScoreChange;
    }
}
