using System;
using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject playerNameContainer;
    public GameObject menuContainer;

    public GameObject playerNameField;
    public GameObject currentPlayerName;
    
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
        playerNameContainer.SetActive(false);
        menuContainer.SetActive(true);
    }

    public void SetPlayerName()
    {
        DataManager.Instance.currentPlayerName = playerNameField.GetComponent<TMP_InputField>().text;
        DisplayGameMenu();
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
