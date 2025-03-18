using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimations playerAnimator;
    private bool hasTheTorch = false; // Default: Player does not have the torch

    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimations>();
    }

    public bool HasTheTorch()
    {
        return hasTheTorch;
    }

    public void ActivateTheTorch()
    {
        hasTheTorch = true;
        Debug.Log("Player has 'The Torch'!");
    }
}