using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    public void LoadGameScene()
    {
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
