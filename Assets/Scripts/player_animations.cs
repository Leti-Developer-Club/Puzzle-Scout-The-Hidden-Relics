using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;

    [SerializeField] private Player player;
    [SerializeField] private string walkingParameter = "IS_WALKING"; // Animator parameter for walking
    bool moving = false;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void Walk()
    {
        // Trigger walking animation
        if (playerAnimator != null)
        {
            playerAnimator.SetBool(walkingParameter, true);
            Debug.Log("Player is walking");
        }
        else
        {
            Debug.LogError("Couldn't find animator");
        }
        moving = true;
    }

    // Stop the player
    public void Idle()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool(walkingParameter, false);
            Debug.Log("Player is not walking");
        }
        else
        {
            Debug.LogError("Couldn't find animator");
        }
        moving = false;
    }

    // Check if the player is walking based on velocity
    public bool IsWalking()
    {
        return moving;
    }
}