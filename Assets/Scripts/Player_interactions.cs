using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask animalLayer; 
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

   private void OnCollisionEnter2D(Collision2D collision)
{
    if (((1 << collision.gameObject.layer) & animalLayer) != 0)
    {
        Debug.Log($"Collision detected: {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent(out Animal animal))
        {
            HandleInteraction(animal);
        }
    }
}


    private void HandleInteraction(Animal animal)
    {
        if (playerInventory.HasTorch)
        {
            animal.HandleAnimalDefeat(); // Play death animation and destroy animal
        }
        // else
        // {
        //     GameManager.Instance.LoseGame(); // Trigger Game Over
        // }
    }
}
