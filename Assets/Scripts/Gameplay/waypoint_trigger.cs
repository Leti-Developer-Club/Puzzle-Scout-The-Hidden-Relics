using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    [SerializeField] private int waypointIndex; // The index of this waypoint

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.PlayerReachedWaypoint(waypointIndex);
        }
    }
}
