using UnityEngine;
using UnityEngine.UI;

public class ToggleClickAnimation : MonoBehaviour
{
    private Toggle toggle;
    private RectTransform toggleTransform;
    private Vector3 originalScale;

    // Animation parameters
    public float clickScaleFactor = 1.1f;
    public float clickAnimationDuration = 0.2f;

    void Start()
    {
        // Get the toggle component
        toggle = GetComponent<Toggle>();

        // Get the RectTransform component of the toggle
        toggleTransform = toggle.GetComponent<RectTransform>();

        // Store the original scale for restoration
        originalScale = toggleTransform.localScale;

        // Add listener for toggle value change event
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isOn)
    {
        // You can add actions or animations for toggle value change here
        Debug.Log("Toggle Value Changed: " + isOn);

        // Example: Scale up animation when the toggle is clicked
        if (isOn)
        {
            LeanTween.scale(toggleTransform, originalScale * clickScaleFactor, clickAnimationDuration)
                .setEase(LeanTweenType.easeOutQuad)
                .setOnComplete(() =>
                {
                    // Reset the scale after the animation completes
                    LeanTween.scale(toggleTransform, originalScale, clickAnimationDuration);
                });
        }
    }
}
