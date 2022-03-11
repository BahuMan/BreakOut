using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Counting.Instance.ScoreChangeHandler += OnScoreChange;
        scoreText = GetComponent<Text>();
    }

    private void OnScoreChange(int newScore)
    {
        scoreText.text = "" + newScore;
    }
}
