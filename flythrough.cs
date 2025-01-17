using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flythrough : MonoBehaviour
{
    [Header("Flythrough Settings")]
    public Transform[] waypoints;       // Array of waypoints to follow
    public float moveSpeed = 5f;        // Speed of movement
    public float rotationSpeed = 2f;    // Speed of rotation
    public bool loop = true;            // Loop the flythrough

    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Update()
    {
        if (waypoints.Length == 0) return;

        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        Transform target = waypoints[currentWaypointIndex];

        // Move towards the current waypoint
        Vector3 moveDirection = target.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Smoothly rotate towards the target
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if we reached the current waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                if (loop)
                    currentWaypointIndex = 0; // Restart at the first waypoint
                else
                    enabled = false; // Stop the script when done
            }
        }
    }

    // Gizmos for visualizing waypoints
    void OnDrawGizmos()
    {
        if (waypoints.Length > 0)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < waypoints.Length; i++)
            {
                Gizmos.DrawSphere(waypoints[i].position, 0.3f);
                if (i > 0)
                    Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
            }
        }
    }
}
