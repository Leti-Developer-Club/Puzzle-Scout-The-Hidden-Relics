using UnityEngine;

public class RockController : MonoBehaviour
{
    [Header("Rock Properties")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask hazardLayer;
     [SerializeField] private Collider2D object1Collider; 
    [SerializeField] private Collider2D object2Collider; 
     BoxCollider2D boxCollider2D;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            boxCollider2D = GetComponent<BoxCollider2D>();
    }
   

    private void Start()
    {
        if (object1Collider != null && object2Collider != null)
        {
            Physics2D.IgnoreCollision(object1Collider, object2Collider, true);
            Debug.Log("Ignoring collision between " + object1Collider.name + " and " + object2Collider.name);
        }
        else
        {
            Debug.LogError("Colliders are not assigned!");
        }
    }

    // private void Update()
    // {
    //     if (!hasLanded)
    //     {
    //         CheckForLanding();
    //     }
    // }

    // private void CheckForLanding()
    // {
    //     // Check if the rock has stopped moving (landed)
    //     if (rb.linearVelocity.magnitude < 0.1f)
    //     {
    //         Collider2D hazard = Physics2D.OverlapCircle(transform.position, groundCheckRadius, hazardLayer);
    //         if (hazard != null)
    //         {
    //             DisableHazard(hazard.gameObject);
    //         }

    //         hasLanded = true; // Prevent multiple detections
    //     }
    // }

    private void DisableHazard(GameObject hazard)
    {
        Debug.Log($"Rock landed on Venomous plant, disabling hazard.");
        
        hazard.SetActive(false);

        // Change the rock's layer to allow player to walk on it
        gameObject.layer = LayerMask.NameToLayer("Walkable");

    }
    // public void ReleaseRock()
    // {
    //     if (!hasFallen)
    //     {
    //         hasFallen = true;
    //         rb.bodyType = RigidbodyType2D.Dynamic; // Enable physics so the rock can fall
    //         rb.gravityScale = 1; // Set gravity for natural falling
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Hazard")) // Check if colliding with a hazard
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        DisableHazard(collision.gameObject);

    }
}

}
