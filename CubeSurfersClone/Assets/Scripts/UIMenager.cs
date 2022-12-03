using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenager : MonoBehaviour
{
    /// <summary>
    /// General UI menager.
    /// </summary>

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
