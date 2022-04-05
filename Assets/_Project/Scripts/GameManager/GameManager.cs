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
    public int maxScore;

    public string namePlayer;
    public string namePlayerBest;

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
        DontDestroyOnLoad(gameObject);
        LoadScore();
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
        if (score > maxScore)
        {
            maxScore = score;
            namePlayerBest = namePlayer;
        }

        score = 0;

        SaveScore();
    }


    [Serializable]
    class SaveData
    {
        public string namePlayerBest;
        public int maxScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.namePlayerBest = namePlayerBest;
        data.maxScore = maxScore;

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText("Assets/savescore.json", json);

    }

    public void LoadScore()
    {
        string path = "Assets/savescore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            namePlayerBest = data.namePlayerBest;
            maxScore = data.maxScore;
        }
    }

    public void ResetScore()
    {
        string path = "Assets/savescore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            namePlayerBest = null;
            maxScore = 0;
        }
    }
}
