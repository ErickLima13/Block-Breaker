using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData : IComparable
{
    public string namePlayer;
    public int Score;

    public SaveData() { }

    public SaveData(string name, int score)
    {
        namePlayer = name;
        Score = score;
    }

    public int CompareTo(object obj)
    {
        var otherPlayerScore = obj as SaveData;

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
