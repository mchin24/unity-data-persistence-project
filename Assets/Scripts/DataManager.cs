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
        // Find the correct place to insert the new score
        int insertIndex = -1;
        for (int i = 0; i < _highScores.Length; i++)
        {
            if (score > _highScores[i].score)
            {
                insertIndex = i;
                break;
            }
        }
        
        if (insertIndex > -1)
        {
            // Move all other scores down
            for (int i = _highScores.Length - 1; i > insertIndex; i--)
            {
                _highScores[i] = _highScores[i - 1];
            }
            
            // Then insert the new score
            _highScores[insertIndex] = new GameScore{playerName = playerName, score = score};

            // Then save
            Save();
        }
    }
    
    public GameScore[] GetHighScores()
    {
        return _highScores;
    }


    [Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public GameScore[] highScores;
    }
    
    public void Save()
    {
        SaveData data = new SaveData
        {
            currentPlayerName = currentPlayerName,
            highScores = _highScores
        };
            
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    
    public void Load()
    {
        // Set initial values
        currentPlayerName = "Default";
        for (int i = 0; i < _highScores.Length; i++)
        {
            _highScores[i] = new GameScore{playerName = currentPlayerName, score = 0};
        }
        
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            currentPlayerName = data.currentPlayerName;
            _highScores = data.highScores;
        }
    }
}
