using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ScoreData 
{
    public List<PlayerScore> playerScores = new List<PlayerScore>(10);
}
