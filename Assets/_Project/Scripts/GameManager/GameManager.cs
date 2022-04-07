using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
   
    public string namePlayer = "Player 1";
   
    public int lives = 3;

    public bool isGameOver;

    public TextMeshProUGUI textName;

    public static GameManager instance;

    public string playerName;

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

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            isGameOver = true;
            GameOver();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        isGameOver = false;
        namePlayer = textName.text;
        playerName = namePlayer;
        lives = 3;
    }

    public void GameOver()
    {
        

        score = 0;   
    }


  
   
}
