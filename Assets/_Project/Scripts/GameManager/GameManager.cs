using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void GameControllHandler();
    public GameControllHandler onGameOver;

    public int score;
   
    public string namePlayer;
    
    public int lives = 3;

    public TextMeshProUGUI textName;

    public static GameManager instance;

    public string playerName;

    public bool gameOver;

    [SerializeField] private LeaderBoard leaderBoard;

    private void Initialization()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        Initialization();
    }

    public void CountLives()
    {
        if(lives > 0)
        {
            lives--;
        }
        else
        {
            onGameOver?.Invoke();
            gameOver = true;
            leaderBoard.EndGameScore();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
        namePlayer = textName.text;
        playerName = namePlayer;
        lives = 3;
        score = 0;
    }
}
