using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelControl : MonoBehaviour
{

    [SerializeField]
    string nextLevel;

    private void OnEnable()
    {
        Counting.Instance.OnLevelFinished += counting_levelFinished;
    }

    private void OnDisable()
    {
        Counting.Instance.OnLevelFinished -= counting_levelFinished;
    }

    private void counting_levelFinished()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }
}
