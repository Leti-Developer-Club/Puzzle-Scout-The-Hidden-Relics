using UnityEngine;

public class TorchPickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.HasTorch = true;
                Destroy(gameObject); // Removes the torch after pickup
            }
        }
    }
}
