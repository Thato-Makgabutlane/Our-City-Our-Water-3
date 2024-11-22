using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLoop : MonoBehaviour
{
    [SerializeField] Vector3 customRotation; //Set correct forward rotation

    public List<Transform> positions;  // List of positions to move through
    public float moveSpeed = 1.0f;      // Speed of movement
    public float rotationSpeed = 5.0f;  // Speed of rotation
    public int currentIndex = 0;       // Current position index

    void Update()
    {
        if (positions.Count == 0) return;

        // Move the object towards the next position
        MoveTowardsNextPosition();

        // Rotate the object to face the direction of the next position
        RotateTowardsNextPosition();
    }

    private void MoveTowardsNextPosition()
    {
        // Get the target position
        Vector3 targetPosition = positions[currentIndex].position;

        // Move the object towards the next position using MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the object has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)  // Small threshold to avoid precision issues
        {
            // Update to the next position index
            currentIndex = (currentIndex + 1) % positions.Count;
        }
    }

    private void RotateTowardsNextPosition()
    {
        // Direction to the next position
        Vector3 direction = positions[currentIndex].position - transform.position;

        // Check if there's direction to move to avoid rotating to zero direction
        if (direction != Vector3.zero)
        {
            // Calculate the target rotation based on the direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Correct for the object's initial rotation (e.g., if it's 90 degrees off in Y axis)
            Quaternion correctedRotation = targetRotation * Quaternion.Euler(customRotation);  // Adjust Y-axis by 90 degrees (or another value if needed)

            // Smoothly rotate towards the corrected rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, correctedRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
