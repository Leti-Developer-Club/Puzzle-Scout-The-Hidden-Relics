using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Transform[] Points;

    [SerializeField] private float moveSpeed;

    private int pointsIndex;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(pointsIndex <= Points.Length -1) 
       {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
       }
    }
}
