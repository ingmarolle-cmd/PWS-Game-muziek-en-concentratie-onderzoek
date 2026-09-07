using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;

    void Awake()
    {
        // simple singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void GameOver()
    {
        if (isGameOver) return; // don't double-trigger

        isGameOver = true;
        Time.timeScale = 0f; // freeze the game (stops scrolling, spawning, movement)
        Debug.Log("Game Over!");
        // TODO: show a Game Over UI panel here instead of just logging
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // un-freeze before reloading, or the new scene loads paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}