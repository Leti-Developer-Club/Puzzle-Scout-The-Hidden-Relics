using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Debug.Log("Hazard hit Player!");

            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            Debug.Log("PlayerInventory found: " + (playerInventory != null));

            if (GameManager.Instance != null)
            {
                GameManager.Instance.HazardEncountered(playerInventory);
            }
            else
            {
                Debug.LogWarning("GameManager.Instance is null");
            }
        }
    }
    private void OnEnable()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
            collider.enabled = true;
        }
    }


}
