using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentPlayerName;
    private GameScore[] _highScores = new GameScore[10];

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    
    [Serializable]
    public class GameScore
    {
        public int score;
        public string playerName;
    }

    public void AddScore(int score, string playerName)
    {
        
    }
    
    public GameScore[] GetHighScores()
    {
        return _highScores;
    }


    [Serializable]
    class SaveData
    {
        public string currentPlayerName;
    }
    
    public void Save()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
            
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    
    public void Load()
    {
        // Set initial values
        currentPlayerName = "";
        for (int i = 0; i < _highScores.Length; i++)
        {
            _highScores[i] = new GameScore{playerName = "AAA", score = 0};
        }
        
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            currentPlayerName = data.currentPlayerName;
        }
    }
}
