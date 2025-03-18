using UnityEngine;

public class Hazard : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.HazardEncountered(playerInventory);
        }
    }
}

}
