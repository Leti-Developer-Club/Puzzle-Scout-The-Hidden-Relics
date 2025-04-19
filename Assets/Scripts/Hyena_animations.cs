using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimations : MonoBehaviour
{
    private Animator hyenaAnimator;
    
    [SerializeField] private Animal animal; // Reference to the animal logic
    public const string walkingParameter = "isWalking";

    private void Awake()
    {
        hyenaAnimator = GetComponent<Animator>();
    }

    public void Die()
    {
        if (hyenaAnimator != null && animal.isDefeated)
        {
            hyenaAnimator.SetBool(walkingParameter, false);
            Debug.Log("Animal died");
        }
        else
        {
            Debug.LogError("Couldn't find animator");
        }
        animal.isDefeated = true;
    }
}
