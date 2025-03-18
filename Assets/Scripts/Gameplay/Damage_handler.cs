using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private LevelHandler gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            PlayerInventory playerInventory = GetComponent<PlayerInventory>();

            if (playerInventory != null && playerInventory.HasTorch)
            {
                Debug.Log("Player has the torch and survived the hazard.");
                GameManager.Instance.WinGame(); 
            }
            else
            {
                TriggerDeath();
            }
        }
    }

    private void TriggerDeath()
    {
        Debug.Log("Player touched a hazard and died!");
        FindAnyObjectByType<LevelHandler>().GameOver();
    }
}
