using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    public List<TextMeshProUGUI> rankName = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> rankScore = new List<TextMeshProUGUI>();

    [SerializeField] private LeaderBoard leaderBoard;

    // Start is called before the first frame update
    void Start()
    {
        leaderBoard.Load();
        
        

    
    }

    // Update is called once per frame
    void Update()
    {
        SaveData record = new SaveData();

        if (GameManager.instance.isGameOver)
        {
            record.namePlayer = GameManager.instance.namePlayer;
            record.Score = GameManager.instance.score;

            leaderBoard.EndGameScore(record);
        }

        

        for (int i = 0; i < 10; i++)
        {
            rankName[i].text = record.namePlayer;
            rankScore[i].text = record.Score.ToString();
        }
    }
}
