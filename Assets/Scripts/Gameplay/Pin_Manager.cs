using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance { get; private set; }

    [SerializeField] private CharacterMovementWithPinLogic characterMovement;
    [SerializeField] private List<PinController> pins;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public void NotifyPinRemoved()
    {
        if (pins == null || pins.Count == 0)
        {
            Debug.LogError("Pins list is null or empty!");
            return;
        }
        AreAllPinsRemoved();

        // Check if all pins are removed
        if (AreAllPinsRemoved())
        {
            Debug.Log("All pins removed. Allowing character movement.");
            characterMovement.StartMovement(); // Notify the character to start moving
        }
    }

    private bool AreAllPinsRemoved()
    {
        foreach (var pin in pins)
        {
            if (!pin.IsRemoved)
            {
                return false;
            }
        }
        return true;
    }

    private void Start()
    {
        if (pins == null) // Safety check
            pins = new List<PinController>();
    }
}
