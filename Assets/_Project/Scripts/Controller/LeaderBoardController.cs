using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> rankName = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> rankScore = new List<TextMeshProUGUI>();

    [SerializeField] private LeaderBoard leaderBoard;

    public void ShowRecord()
    {
        try
        {
            for (int i = 0; i < leaderBoard.data.playerScores.Count; i++)
            {
                rankName[i].text = leaderBoard.data.playerScores[i].namePlayer;
                rankScore[i].text = leaderBoard.data.playerScores[i].Score.ToString();
            }
        }
        catch (ArgumentOutOfRangeException)
        {
             
        }
    }

    public void LoadRecord()
    {
        leaderBoard.Load();
        ShowRecord();
    }
}
