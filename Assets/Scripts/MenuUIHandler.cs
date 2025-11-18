using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject playerNameContainer;
    public GameObject menuContainer;

    public GameObject playerNameField;
    public GameObject currentPlayerName;
    public GameObject bestScoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (String.IsNullOrEmpty(DataManager.Instance.currentPlayerName))
        {
            DisplayNameField();
        }
        else
        {
            DisplayGameMenu();
        }
    }

    public void DisplayNameField()
    {
        playerNameField.GetComponent<TMP_InputField>().text = DataManager.Instance.currentPlayerName;
        playerNameContainer.SetActive(true);
        menuContainer.SetActive(false);
    }

    public void DisplayGameMenu()
    {
        currentPlayerName.GetComponent<TMP_Text>().text = "Player: " + DataManager.Instance.currentPlayerName;
        DataManager.GameScore bestScore = DataManager.Instance.GetHighScores()[0];
        bestScoreText.GetComponent<TMP_Text>().text = $"Best Score : {bestScore.playerName} : {bestScore.score}";
        playerNameContainer.SetActive(false);
        menuContainer.SetActive(true);
    }

    public void SetPlayerName()
    {
        DataManager.Instance.currentPlayerName = playerNameField.GetComponent<TMP_InputField>().text;
        DataManager.Instance.Save();
        DisplayGameMenu();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ShowScores()
    {
        SceneManager.LoadScene("scores");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
