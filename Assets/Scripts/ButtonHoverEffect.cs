using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform buttonTransform; // The RectTransform of the button
    public Vector3 enlargedScale = new Vector3(1.2f, 1.2f, 1.2f); // The scale when the button is enlarged
    public float animationSpeed = 10f; // Speed of scaling animation

    private Vector3 originalScale; // The original scale of the button
    private bool isHovered = false; // Flag to check if the button is hovered

    void Start()
    {
        originalScale = buttonTransform.localScale;
    }

    void Update()
    {
        if (isHovered)
        {
            // Smoothly enlarge the button when hovered
            buttonTransform.localScale = Vector3.Lerp(buttonTransform.localScale, enlargedScale, Time.deltaTime * animationSpeed);
        }
        else
        {
            // Smoothly return to the original size when not hovered
            buttonTransform.localScale = Vector3.Lerp(buttonTransform.localScale, originalScale, Time.deltaTime * animationSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}