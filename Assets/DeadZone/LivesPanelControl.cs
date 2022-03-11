using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class LivesPanelControl : MonoBehaviour
{

    [SerializeField]
    Image Hartje;

    Stack<Image> lives;

    private void Start()
    {
        lives = new Stack<Image>(10);

        //immediately call our method to update the hearts for the first time:
        counting_livesChanged(Counting.Instance.Lives);
    }

    private void counting_livesChanged(int newLives)
    {
        while (lives.Count < newLives)
        {
            Image newHeart = Instantiate<Image>(Hartje);
            newHeart.transform.SetParent(this.transform);
            lives.Push(newHeart);
        }

        while (lives.Count > newLives)
        {
            Image toRemove = lives.Pop();
            Destroy(toRemove.gameObject);
        }
    }

    private void OnEnable()
    {
        Counting.Instance.LivesChangedHandler += counting_livesChanged;
    }

    private void OnDisable()
    {
        Counting.Instance.LivesChangedHandler -= counting_livesChanged;
    }
}
