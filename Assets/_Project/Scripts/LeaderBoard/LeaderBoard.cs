using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private List<SaveData> data = new List<SaveData>();

    // Start is called before the first frame update
    void Start()
    {
        SaveSystem.Init();
    }

    public void Save()
    {
        data.Sort();
        string dataRecord = JsonUtility.ToJson(data);
        SaveSystem.SaveScore(dataRecord);
    }

    public void Load() 
    {
        string dataLoaded = SaveSystem.LoadScore();

        if(dataLoaded != null)
        {
            data = JsonUtility.FromJson<List<SaveData>>(dataLoaded);
        }
    }

    public void EndGameScore(SaveData dataReceived) // chamar no final da partida
    {
        data.Add(dataReceived);
        Save();
    }

    

}
