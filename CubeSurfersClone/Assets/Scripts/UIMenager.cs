using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject levelCompleteUI;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelCompleteUI()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }


}
