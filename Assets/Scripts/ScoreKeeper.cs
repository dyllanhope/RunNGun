using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    static ScoreKeeper instance;

    int currentScore = 0;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
}
