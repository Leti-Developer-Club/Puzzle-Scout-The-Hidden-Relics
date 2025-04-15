using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    private Rigidbody2D rb; 

    private Animal_Animations anim;

    private void Awake()
{
    rb = GetComponent<Rigidbody2D>();
    anim = FindAnyObjectByType<Animal_Animations>();
}

    private void Update()
{
    if (waypoints.Length > 0 && anim != null)
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
    private void OnDrawGizmos()
{
    Gizmos.color = Color.green;

    for (int i = 0; i < waypoints.Length; i++)
    {
        Vector3 current = waypoints[i].position;
        Vector3 next = waypoints[(i + 1) % waypoints.Length].position;
        Gizmos.DrawLine(current, next);
    }
}
}
