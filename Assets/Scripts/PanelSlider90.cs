using UnityEngine;
using UnityEngine.UI;

public class PanelSlider90 : MonoBehaviour
{
    public RectTransform panel; // The panel to slide
    public Button toggleButton;  // The button that triggers the slide
    public float slideSpeed = 300f; // Speed of sliding
    public float slideDistance = 200f; // Distance to slide up or down

    private Vector2 originalPosition; // Original position of the panel
    private bool isPanelUp = false;   // Whether the panel is currently up
    private bool isSliding = false;   // Whether the panel is currently sliding

    void Start()
    {
        originalPosition = panel.anchoredPosition;
        toggleButton.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        if (isSliding) return; // Prevent toggling while the panel is moving
        isSliding = true;

        if (isPanelUp)
        {
            // Slide down
            StartCoroutine(SlidePanel(originalPosition));
        }
        else
        {
            // Slide up
            StartCoroutine(SlidePanel(new Vector2(originalPosition.x, originalPosition.y + slideDistance)));
        }
    }

    System.Collections.IEnumerator SlidePanel(Vector2 targetPosition)
    {
        while (Vector2.Distance(panel.anchoredPosition, targetPosition) > 0.01f)
        {
            panel.anchoredPosition = Vector2.MoveTowards(panel.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
            yield return null;
        }

        panel.anchoredPosition = targetPosition;
        isPanelUp = !isPanelUp;
        isSliding = false;
    }
}