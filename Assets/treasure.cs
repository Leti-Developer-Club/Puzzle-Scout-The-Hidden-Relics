using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    [Header("State Settings")]
    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;
    private LevelHandler levelHandler;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // Default to closed sprite
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen && other.CompareTag("Player")) // Automatically open when player touches it
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite; // Change sprite to open chest
        Debug.Log("Chest opened! Reward collected.");
        levelHandler.CompleteLevel();

        // Optional: Instantiate a reward item if assigned
        // if (rewardPrefab != null)
        // {
        //     Instantiate(rewardPrefab, transform.position + Vector3.up, Quaternion.identity);
        // }

        // Notify GameManager that a treasure is collected
        // GameManager.Instance.CollectTreasure(treasureValue);
    }
}
