using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentPlayerName;
    public int highScore;

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
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            currentPlayerName = data.currentPlayerName;
        }
    }
}
