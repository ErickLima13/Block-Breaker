using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    public List<TextMeshProUGUI> rankName = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> rankScore = new List<TextMeshProUGUI>();

    [SerializeField] private LeaderBoard leaderBoard;

    public void ShowRecord()
    {
        for (int i = 0; i < leaderBoard.data.playerScores.Count; i++)
        {
            rankName[i].text = leaderBoard.data.playerScores[i].namePlayer;
            rankScore[i].text = leaderBoard.data.playerScores[i].Score.ToString();
        }
    }

    public void LoadRecord()
    {
        leaderBoard.Load();
        leaderBoard.data.playerScores.Reverse();
        ShowRecord();
    }
}
