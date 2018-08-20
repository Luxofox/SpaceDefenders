using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour {

    public GameObject gameOverUI;
    public GameObject gameWinUI;
    // Use this for initialization


    void Update()
    {
        if (ScoreManager.Lives <= 0)
        {
            ShowGameOverUI();

        }
        if (EnemySpawner.wavesRestantes <= 0   && Enemy.numberOfEnemies <= 0)
        {
            gameWinUI.SetActive(true);
            

        }

    }
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void GameOver()
    {

        Time.timeScale = 1f;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("MenuPrincipal");


    }

    public void WinGame()
    {
        Time.timeScale = 1f;
        gameWinUI.SetActive(false);
        SceneManager.LoadScene("MenuPrincipal");
    }


}
