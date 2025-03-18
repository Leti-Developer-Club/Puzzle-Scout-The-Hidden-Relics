using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    private Rigidbody2D rb; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (waypoints.Length > 0 && FindAnyObjectByType<Animal_Animations>())
        {
            MoveAlongWaypoints();
        }
    }

    private void MoveAlongWaypoints()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPosition);

        if (Vector2.Distance(rb.position, targetWaypoint.position) < 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
