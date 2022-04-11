using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerScore : IComparable
{
    public string namePlayer = "Empty";
    public int Score = 1;

    public PlayerScore() { }

    public PlayerScore(string name, int score)
    {
        namePlayer = name;
        Score = score;
    }

    public int CompareTo(object obj)
    {
        var otherPlayerScore = obj as PlayerScore;

        if(Score < otherPlayerScore.Score || otherPlayerScore == null)
        {
            return -1;
        }
        else if(Score == otherPlayerScore.Score)
        {
            return 0;
        }

        return 1;
    }
}
