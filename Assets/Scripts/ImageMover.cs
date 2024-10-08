using UnityEngine;
using UnityEngine.UI;

public class ImageMover : MonoBehaviour
{
    public RectTransform image; // The UI image to move
    public Transform[] waypoints; // Array of waypoints to move towards
    public float speed = 1f; // Speed of movement

    private int currentWaypointIndex = 0; // Current waypoint index

    private void Update()
    {
        // Move towards the current waypoint if it exists
        if (currentWaypointIndex < waypoints.Length)
        {
            MoveToWaypoint(waypoints[currentWaypointIndex]);
        }
    }

    private void MoveToWaypoint(Transform waypoint)
    {
        // Calculate the step size based on speed and time
        float step = speed * Time.deltaTime;

        // Move the image towards the waypoint position
        image.position = Vector3.MoveTowards(image.position, waypoint.position, step);

        // Check if the image has reached the waypoint
        if (Vector3.Distance(image.position, waypoint.position) < 0.1f)
        {
            // Increment the waypoint index to move to the next one
            currentWaypointIndex++;
        }
    }
}