using UnityEngine;
using UnityEngine.UI; // Use this if you're using the default UI Text
// using TMPro; // Uncomment this line if you're using TextMeshPro

public class TextSwitcher : MonoBehaviour
{
    public Text targetText; // Reference to the Text component (use TextMeshProUGUI if using TextMeshPro)
    // public TextMeshProUGUI targetText; // Uncomment this if using TextMeshPro

    public string newText = "Hello, World!"; // The new text to switch to
    public float displayDuration = 2f; // Duration to display the original text before switching
    private bool hasSwitched = false; // Track whether the text has been switched

    private void Start()
    {
        // Start the timer to switch the text
        StartCoroutine(SwitchTextAfterDelay(displayDuration));
    }

    private System.Collections.IEnumerator SwitchTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified duration

        SwitchText(); // Switch the text after the delay
    }

    // This method can be called to switch the text
    public void SwitchText()
    {
        if (!hasSwitched) // Check if the text has already been switched
        {
            targetText.text = newText; // Change the text
            hasSwitched = true; // Set the flag to true to prevent further changes
        }
    }
}