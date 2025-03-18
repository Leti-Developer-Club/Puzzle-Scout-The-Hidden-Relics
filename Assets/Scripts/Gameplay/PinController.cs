using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PinController : MonoBehaviour
{
    [Header("Pin Settings")]
    [SerializeField] private float moveDistance = 3f; // Distance the pin moves when removed
    [SerializeField] private float animationDuration = 0.5f; // Duration of the removal animation

    public bool IsRemoved { get; private set; } // Tracks if the pin is removed

    private void OnMouseDown()
    {
        if (!IsRemoved)
        {
            RemovePin();
        }
    }

    private void RemovePin()
    {
        IsRemoved = true;

        // Notify the PinManager
        PinManager.Instance.NotifyPinRemoved();

        // Calculate the target position based on the pin's current rotation
        Vector3 targetPosition = transform.position + (transform.up * moveDistance);

        // Move and fade out the pin
        transform.DOMove(targetPosition, animationDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }
}
