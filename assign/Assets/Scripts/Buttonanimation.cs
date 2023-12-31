using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    private Button button;
    private RectTransform buttonTransform;
    private Vector3 originalScale;

    // Animation parameters
    public float scaleFactor = 1.1f;
    public float animationDuration = 0.2f;

    void Start()
    {
        // Get the button component
        button = GetComponent<Button>();

        // Get the RectTransform component of the button
        buttonTransform = button.GetComponent<RectTransform>();

        // Store the original scale for restoration
        originalScale = buttonTransform.localScale;

        // Add listener for button click event
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // You can add actions or animations for button click here
        Debug.Log("Button Clicked!");
    }

    void Update()
    {
        // Check if the mouse is over the button for hover animation
        if (RectTransformUtility.RectangleContainsScreenPoint(buttonTransform, Input.mousePosition))
        {
            // Scale up animation on mouse hover if not already scaled
            if (!LeanTween.isTweening(buttonTransform.gameObject))
            {
                LeanTween.scale(buttonTransform, originalScale * scaleFactor, animationDuration);
            }
        }
        else
        {
            // Scale down animation when not hovering if not already scaled down
            if (buttonTransform.localScale != originalScale && !LeanTween.isTweening(buttonTransform.gameObject))
            {
                LeanTween.scale(buttonTransform, originalScale, animationDuration);
            }
        }
    }
}
