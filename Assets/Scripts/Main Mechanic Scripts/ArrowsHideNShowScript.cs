using UnityEngine;

public class PannelHideNShowScript : MonoBehaviour
{
    public GameObject[] mainPanels;
    public GameObject[] hidePanels;

    public void Start()
    {
    }
    public void TogglePanel(int index)
    {
        if (mainPanels != null && index >= 0 && index < mainPanels.Length)
        {
            GameObject panel = mainPanels[index];
            panel.SetActive(!panel.activeSelf);
        }
    }
    public void DisableAllPanels() 
    {
        foreach (GameObject panel in hidePanels) 
        {
            if (panel != null)
                panel.SetActive(false);
        }
    }
    public void EnableAllPanels() 
    {
        foreach (GameObject panel in hidePanels) 
        {
            if (panel != null)
                panel.SetActive(true);
        }
    }
}