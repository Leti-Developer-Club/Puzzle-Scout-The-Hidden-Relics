using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player and Level Settings")]
    [SerializeField] private Transform[] waypoints; 
    [SerializeField] private Player player; 
    private int currentWaypointIndex = 0; 

    [Header("Level Handler")]
    [SerializeField] private LevelHandler levelHandler; 

    private bool hasEncounteredHazard = false; 
    public static GameManager Instance { get; private set; }
   

     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        
        if (!hasEncounteredHazard && currentWaypointIndex == waypoints.Length - 1)
        {
            WinGame();
        }
    }

    public void PlayerReachedWaypoint(int waypointIndex)
    {
        if (waypointIndex > currentWaypointIndex)
        {
            currentWaypointIndex = waypointIndex; 
            Debug.Log($"Player reached waypoint {currentWaypointIndex}");
        }
    }

    public void HazardEncountered(PlayerInventory playerInventory)
{
    if (!hasEncounteredHazard)
    {
        if (playerInventory != null && playerInventory.HasTorch)
        {
            Debug.Log("Player has the torch, avoiding hazard!");
            WinGame(); 
        }

        else
        {
            hasEncounteredHazard = true;
            Debug.Log("Player hit a hazard! Triggering Game Over.");
            LoseGame();
        }
    }
}


    public void WinGame()
    {
        
        if (!hasEncounteredHazard && currentWaypointIndex == waypoints.Length - 1)
        {
        Debug.Log("You Win!");
        levelHandler.CompleteLevel(); 
        }
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        levelHandler.GameOver(); 
    }
    // public void CollectTreasure(int value)
    // {
    //     collectedTreasures += value;
    //     Debug.Log($"Total Treasures Collected: {collectedTreasures}");
    //     levelHandler.CompleteLevel();
    // }
}
