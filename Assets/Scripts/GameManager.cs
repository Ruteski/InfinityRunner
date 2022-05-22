using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static GameManager instance; // singleton

    // Start is called before the first frame update
    void Start()
    {
        instance = this; // singleton
        Time.timeScale = 1;
    }

    public void ShowGameOver() {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
