using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject pausePanel;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI nameText;

    public GameObject pauseButton;
    public GameObject resumeButton;

    private void Initialization()
    {
        panelGameOver.SetActive(false);
    }

    private void Start()
    {
        Initialization();    
    }

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            ShowHud();
        }
        else
        {
            ShowGameOver();
        }
    }

    private void ShowHud()
    {
        ScoreText.text = GameManager.instance.score.ToString();
        livesText.text = GameManager.instance.lives.ToString();
        nameText.text = GameManager.instance.namePlayer.ToString();
    }

    private void ShowGameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void PlayGame()
    {
        GameManager.instance.lives = 3;
        GameManager.instance.isGameOver = false;
        panelGameOver.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        resumeButton.SetActive(true);
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        resumeButton.SetActive(false);
        AudioListener.pause = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.isGameOver = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

}
