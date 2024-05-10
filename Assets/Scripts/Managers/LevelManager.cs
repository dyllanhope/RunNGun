using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;

    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGameScene()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad("End", loadDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
