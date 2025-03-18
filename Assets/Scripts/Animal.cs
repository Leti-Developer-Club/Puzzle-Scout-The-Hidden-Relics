using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public bool isDefeated = false;

    [Header("UI Panels")]
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject gameOverPanel;

    // Enum to track game state
    private enum GameState { None, Win, Lose }
    private GameState currentState = GameState.None; // Default state

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (levelCompletePanel == null)
            Debug.LogWarning("Level Complete Panel is not assigned in the Inspector!");

        if (gameOverPanel == null)
            Debug.LogWarning("Game Over Panel is not assigned in the Inspector!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDefeated)
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

            if (playerInventory != null)
            {
                Debug.Log("PlayerInventory found. HasTorch: " + playerInventory.HasTorch);

                switch (playerInventory.HasTorch)
                {
                    case true:
                        currentState = GameState.Win;
                        HandleAnimalDefeat();
                        break;
                    case false:
                        currentState = GameState.Lose;
                        GameManager.Instance.LoseGame();
                        break;
                }
            }
            else
            {
                Debug.LogError("Player does not have PlayerInventory script attached!");
            }
        }
    }

    public void HandleAnimalDefeat()
    {
        if (currentState != GameState.Win) return; 
        
        isDefeated = true;
        animator.SetTrigger("Die");
        Debug.Log("Animal defeated! Level Complete.");
        
        GameManager.Instance.WinGame();

        // StartCoroutine(ShowLevelCompletePanel());
    }

    // private IEnumerator ShowLevelCompletePanel()
    // {
    //     yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        
    //     if (levelCompletePanel != null)
    //     {
    //         levelCompletePanel.SetActive(true);
    //     }
    // }

    // private void TriggerGameOver()
    // {
    //     if (currentState != GameState.Lose) return; 
    //     Debug.Log("Game Over triggered.");
    //     if (gameOverPanel != null)
    //     {
    //         gameOverPanel.SetActive(true);
    //     }
    // }
    public bool IsWalking()
{
    if (rb == null)
    {
        Debug.LogError("Rigidbody2D is missing on " + gameObject.name);
        return false;
    }

    return rb.linearVelocity.magnitude > 0.1f; // Checks if the animal is moving
}

}
