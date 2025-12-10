using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    public Camera[] cameras; // Only include cameras with targetTexture = null
    private int currentCameraIndex = 0;

    [Header("Canvases")]
    public Canvas[] canvases; // Drag all canvases you want to control here in Inspector

    void Start()
    {
        DisableAllCanvases();
        // Enable only the first camera GameObject and its Camera component
        for (int i = 0; i < cameras.Length; i++)
        {
            bool active = (i == currentCameraIndex);
            cameras[i].gameObject.SetActive(active);
            cameras[i].enabled = active;
        }
        EnableCanvasAtIndex(currentCameraIndex);
    }

    void Update()
    {

    }

    public void SwitchToNextCam() 
    {
            // Disable current camera GameObject and Camera component
            cameras[currentCameraIndex].gameObject.SetActive(false);
            cameras[currentCameraIndex].enabled = false;

            // Move to next camera
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable new camera GameObject and Camera component
            cameras[currentCameraIndex].gameObject.SetActive(true);
            cameras[currentCameraIndex].enabled = true;

            Debug.Log("Switched to camera: " + cameras[currentCameraIndex].name);
    }

    public void DisableAllCanvases()
    {
        foreach (Canvas canvas in canvases)
        {
            if (canvas != null)
                canvas.enabled = false;
        }
    }

    public void EnableAllCanvases()
    {
        foreach (Canvas canvas in canvases)
        {
            if (canvas != null)
                canvas.enabled = true;
        }
    }

    public void DisableCanvasAtIndex(int index)
    {
        if (index >= 0 && index < canvases.Length && canvases[index] != null)
            canvases[index].enabled = false;
    }

    public void EnableCanvasAtIndex(int index)
    {
        if (index >= 0 && index < canvases.Length && canvases[index] != null)
            canvases[index].enabled = true;
    }
}
