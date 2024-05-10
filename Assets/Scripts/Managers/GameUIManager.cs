using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreKeeper.GetCurrentScore().ToString("00000");
    }
}
