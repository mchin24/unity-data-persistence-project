using System;
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
    }
}
