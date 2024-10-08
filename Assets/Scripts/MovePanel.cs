using UnityEngine;

public class MovePanel : MonoBehaviour
{
    public RectTransform panel; // Reference to the panel's RectTransform
    public float speed = 200f;  // Speed of the panel's movement
    private float screenWidth;  // Width of the screen in pixels

    void Start()
    {
        // Calculate the screen width in canvas units
        screenWidth = Screen.width;

        // Place the panel on the left side of the screen initially
        Vector3 startPos = panel.localPosition;
        startPos.x = -screenWidth / 2 - panel.rect.width;
        panel.localPosition = startPos;
    }

    void Update()
    {
        // Move the panel horizontally
        Vector3 newPosition = panel.localPosition;
        newPosition.x += speed * Time.deltaTime;

        // Check if the panel has moved off the right side of the screen
        if (newPosition.x > screenWidth / 2 + panel.rect.width)
        {
            // Reset the panel's position to the left side of the screen
            newPosition.x = -screenWidth / 2 - panel.rect.width;
        }

        // Apply the new position to the panel
        panel.localPosition = newPosition;
    }
}