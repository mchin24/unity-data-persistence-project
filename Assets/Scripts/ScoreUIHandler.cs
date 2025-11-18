using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUIHandler : MonoBehaviour
{
    public GameObject scoresText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoresText.GetComponent<TMP_Text>().text = "";
        
        if (DataManager.Instance != null)
        {
            DataManager.GameScore[] highScores = DataManager.Instance.GetHighScores();
            for (int i = 0; i < highScores.Length; i++)
            {
                scoresText.GetComponent<TMP_Text>().text += $"<mspace=1em>{(i+1):00}.{highScores[i].playerName,-10} {highScores[i].score, -3:000}</mspace>\n";
            }
        }
        else
        {
            scoresText.GetComponent<TMP_Text>().text = $"{"01.", -5} {"NOPLAYER",-25} {"0",5}";
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
