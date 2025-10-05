using UnityEngine;

public class CanvasToggler : MonoBehaviour
{
    public GameObject targetCanvas;

    private bool isVisible = true;

    public void ToggleCanvas()
    {
        if (targetCanvas == null)
        {
            Debug.LogWarning("[CanvasToggle] Не назначен Canvas!");
            return;
        }

        isVisible = !isVisible;
        targetCanvas.SetActive(isVisible);
    }
}
