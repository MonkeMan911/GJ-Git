using UnityEngine;

public class PannelHideNShowScript : MonoBehaviour
{
    public GameObject[] panels;

    public void Start()
    {
    }
    public void TogglePanel(int index)
    {
        if (panels != null && index >= 0 && index < panels.Length)
        {
            GameObject panel = panels[index];
            panel.SetActive(!panel.activeSelf);
        }
    }
}