using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject StartButton;

    public void Start()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        StartButton.SetActive(false);
        Time.timeScale = 1f;
    }

}
