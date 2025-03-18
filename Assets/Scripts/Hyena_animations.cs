using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Animations : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private Animal animal; // Reference to the animal logic
    public const string IS_WALKING = "IsWalking";
    public const string IS_DEAD = "Die";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animal.isDefeated)
        {
            animator.SetBool(IS_DEAD, true);
            animator.SetBool(IS_WALKING, false); // Stop walking animation
        }
        else
        {
            animator.SetBool(IS_WALKING, animal.IsWalking());
        }
    }
}
