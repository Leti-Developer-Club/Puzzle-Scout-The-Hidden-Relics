using System;
using System.Collections;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [Header("Water Flow Settings")]
    [SerializeField] private float flowSpeed = 2f; // Speed of water flow
    [SerializeField] private bool isFlowingRight = true; // Flow direction

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Apply velocity based on flow direction
        float horizontalVelocity = isFlowingRight ? flowSpeed : -flowSpeed;
        rb.linearVelocity = new Vector2(horizontalVelocity, rb.linearVelocity.y);
    }

    public void SetFlowDirection(bool flowRight)
    {
        isFlowingRight = flowRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            // Stop water flow when obstructed by a pin
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            // Resume flow when pin is removed
            float horizontalVelocity = isFlowingRight ? flowSpeed : -flowSpeed;
            rb.linearVelocity = new Vector2(horizontalVelocity, rb.linearVelocity.y);
        }
    }
}
