using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class CharacterMovementWithPinLogic : MonoBehaviour
{
    [Header("Path Settings")]
    [SerializeField] private List<Transform> waypoints; // List of waypoints defining the path
    [SerializeField] private float moveSpeed = 2f; // Speed of movement

    [Header("Animation Settings")]
    [SerializeField] private Animator playerAnimator; // Reference to character's animator
    // [SerializeField] private string walkingParameter = "IS_WALKING"; // Animator parameter for walking

    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    PlayerAnimations playerAnimations;

    // Method to allow the PinManager to trigger movement
    public void StartMovement()
    {
        playerAnimations = FindAnyObjectByType<PlayerAnimations>();
        if (waypoints.Count > 0 && !isMoving)
        {
            isMoving = true;

            if (playerAnimations != null)
            {
                playerAnimations.Walk();
            }

            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            float distance = Vector3.Distance(transform.position, targetWaypoint.position);
            float duration = distance / moveSpeed;

            // Smooth movement to the next waypoint
            transform.DOMove(targetWaypoint.position, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    currentWaypointIndex++;
                    MoveToNextWaypoint();
                });
        }
        else
        {
            isMoving = false;

            if (playerAnimations != null)
            {
                playerAnimations.Idle();
            }

            OnMovementComplete();
        }
    }

    private void OnMovementComplete()
    {
        FindAnyObjectByType<LevelHandler>().CompleteLevel();
    }
}
