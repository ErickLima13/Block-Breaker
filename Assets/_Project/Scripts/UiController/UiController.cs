using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;

    private void Initialization()
    {
        panelGameOver.SetActive(false);
        GameManager.instance.onGameOver += ShowGameOver;
    }

    private void Start()
    {
        Initialization();    
    }

    private void Update()
    {
       ShowHud();   
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
        GameManager.instance.score = 0;
        panelGameOver.SetActive(false);
        SceneManager.LoadScene("MainScene");
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
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    private void OnDisable()
    {
        GameManager.instance.onGameOver -= ShowGameOver;
    }
}
