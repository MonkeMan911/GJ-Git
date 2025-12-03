using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        // Enable only the first camera
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Disable current camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Move to next camera
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable new camera
            cameras[currentCameraIndex].gameObject.SetActive(true);

            Debug.Log("Switched to camera: " + currentCameraIndex);
        }
    }
}
