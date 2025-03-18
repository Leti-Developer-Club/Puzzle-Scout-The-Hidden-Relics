using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private SceneName currentLevel = SceneName.Level1;
    [SerializeField] private int totalLevels = 5; 

    [Header("UI References")]
    [SerializeField] private GameObject levelCompletePanel; 
    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private GameObject comicPanel;
    [SerializeField] private GameObject PausePanel;
    bool isPaused = false;


    Audio_manager Audio_Manager;
     public static LevelHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum SceneName
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
        Level4,
    }

    private void Start()
    {
        if (levelCompletePanel != null) levelCompletePanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (PausePanel != null) PausePanel.SetActive(false);

        if (Audio_manager.Instance != null)
        {
            Audio_manager.Instance.LoadAudioSettings();
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Complete!");
        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true); 
        }
    }

    public void NextLevel()
    {
        if ((int)currentLevel < totalLevels)
        {
            currentLevel++;
            Debug.Log($"Loading Level {currentLevel}");
            SceneManager.LoadScene(currentLevel.ToString());
        }
        else
        {
            Debug.Log("All levels completed! Returning to main menu.");
            SceneManager.LoadScene(SceneName.MainMenu.ToString());
        }
    }

    public void RestartLevel()
    {
        Debug.Log($"Restarting Level {currentLevel}");
        SceneManager.LoadScene(currentLevel.ToString());
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }

    public void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void SkipCutscene()
    {
        Debug.Log("SkipCutscene triggered");
        if (comicPanel != null)
        {
            comicPanel.SetActive(false);
        }
    }
     public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 
        PausePanel.SetActive(true); 
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 
        PausePanel.SetActive(false); //
    }
    public void QuitGame()
    {
        Time.timeScale = 1f; 
        Application.Quit();
        Debug.Log("Game Closed"); 
    }
}
