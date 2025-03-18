// MainMenuController.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;

    private void Start()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartNewGame()
    {
        // Start a new game by loading the first level
        PlayerPrefs.SetInt("LastSavedLevel",1); // Reset saved progress
        SceneManager.LoadScene(1); 
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("LastSavedLevel "))
        {
            int lastSavedLevel = PlayerPrefs.GetInt("LastSavedLevel ");
            SceneManager.LoadScene("Level" + lastSavedLevel); // Load the last saved level
        }
        else
        {
            Debug.LogWarning("No saved game found. Starting a new game.");
            //StartNewGame(); // Fallback to starting a new game
        }
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
