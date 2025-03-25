using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Animations : MonoBehaviour
{
    private Animator hyenaAnimator;
    
    [SerializeField] private Animal animal; // Reference to the animal logic
    public const string IS_WALKING = "IsWalking";
    public const string IS_DEAD = "Die";

    private void Awake()
    {
        hyenaAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animal.isDefeated)
        {
            hyenaAnimator.SetBool(IS_DEAD, true);
            hyenaAnimator.SetBool(IS_WALKING, false); // Stop walking animation
        }
        else
        {
            hyenaAnimator.SetBool(IS_WALKING, animal.IsWalking());
        }
    }
}
