using UnityEngine;

public class CanvasDisabler : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private Canvas[] canvases; // drag all canvases here in Inspector

    // Disable all canvases
    public void DisableAll()
    {
        foreach (Canvas canvas in canvases)
        {
            if (canvas != null)
                canvas.enabled = false;
        }
    }

    // Enable all canvases
    public void EnableAll()
    {
        foreach (Canvas canvas in canvases)
        {
            if (canvas != null)
                canvas.enabled = true;
        }
    }

    // Disable a specific canvas by index
    public void DisableAtIndex(int index)
    {
        if (index >= 0 && index < canvases.Length && canvases[index] != null)
            canvases[index].enabled = false;
    }

    // Enable a specific canvas by index
    public void EnableAtIndex(int index)
    {
        if (index >= 0 && index < canvases.Length && canvases[index] != null)
            canvases[index].enabled = true;
    }
}
