using UnityEngine;
using UnityEngine.UI;

public class PanelSlider12 : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject
    public float slideSpeed = 5f; // Speed at which the panel slides
    public float waypointX = -300f; // X position of the waypoint

    private bool isPanelVisible = false; // Track if the panel is currently visible

    private void Start()
    {
        // Ensure the panel starts off-screen (assuming it slides in from the left)
        panel.transform.localPosition = new Vector3(-Screen.width, 0, 0);
    }

    public void TogglePanel()
    {
        isPanelVisible = !isPanelVisible; // Toggle the visibility state

        // Start the coroutine to slide the panel
        StartCoroutine(SlidePanel(isPanelVisible));
    }

    private System.Collections.IEnumerator SlidePanel(bool show)
    {
        // Set the target position based on visibility
        Vector3 targetPosition = show ? new Vector3(waypointX, 0, 0) : new Vector3(-Screen.width, 0, 0);
        Vector3 startPosition = panel.transform.localPosition;

        // Smoothly move the panel to the target position
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            panel.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * slideSpeed;
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is set
        panel.transform.localPosition = targetPosition;
    }
}