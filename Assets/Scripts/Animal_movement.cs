using Unity.Entities.UniversalDelegates;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private AnimalAnimations animalAnimations;
    private int currentIndex = 0;
    private bool goingForward = true;
    private bool isDefeated = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animalAnimations = FindAnyObjectByType<AnimalAnimations>();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (waypoints.Length > 1)
        {
            // Start movement after a tiny delay to allow everything to initialize
            Invoke(nameof(NextWaypoint), 0.1f);
        }
        else
        {
            Debug.LogWarning("Not enough waypoints set for movement.");
        }
    }

    private void NextWaypoint()
    {
        Transform target = waypoints[currentIndex];
        float duration = Vector2.Distance(transform.position, target.position) / moveSpeed;

        // Move to target waypoint
        transform.DOMove(target.position, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                UpdateWaypointIndex();
                FlipSprite();
                NextWaypoint();
            });
    }

    private void UpdateWaypointIndex()
    {
        if (goingForward)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = waypoints.Length - 2;
                goingForward = false;
            }
        }
        else
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 1;
                goingForward = true;
            }
        }
    }

    private void FlipSprite()
    {
        if (spriteRenderer == null) return;
        {
            if (goingForward == true)
            {
                spriteRenderer.flipX = true; // flip left
                Debug.Log("Sprite flippled left");
            }
            else
            {
                spriteRenderer.flipX = false; // flip right
                Debug.Log("Sprite flipped right");
            }
        }


    }
    public void StopMovement()
    {
        transform.DOKill();
        Debug.Log("Stopped movement");
    }
}
