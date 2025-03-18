using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // Import DOTween

public class AishaController : MonoBehaviour
{
    public float moveDuration = 1f; // Duration for movement
    public Vector3 targetPosition; // Target position for movement
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveToTarget()
    {
        //if (GameManager.Instance.IsLevelCompleted())
        {
            animator.SetBool("IsWalking", true);
            transform.DOMove(targetPosition, moveDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                animator.SetBool("IsWalking", false);
            });
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
}