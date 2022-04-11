using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public ScoreData data = new ScoreData();

    // Start is called before the first frame update
    void Start()
    {
        SaveSystem.Init();
        
    }

    public void Save()
    {
        string dataRecord = JsonUtility.ToJson(data, true);
        SaveSystem.SaveScore(dataRecord);
    }

    public void Load() 
    {
        string dataLoaded = SaveSystem.LoadScore();

        if(dataLoaded != null)
        {
            data = JsonUtility.FromJson<ScoreData>(dataLoaded);
        }
    }

    public void EndGameScore() 
    {
        PlayerScore currentScore = new PlayerScore(GameManager.instance.namePlayer, GameManager.instance.score);

        data.playerScores.Add(currentScore);
        Debug.LogWarning("ADDED");

        data.playerScores.Sort();
        

        Save();

    }
}
