using UnityEngine;
using UnityEngine.UI;

public class ArrowScrollScript : MonoBehaviour
{
    [Header("UI Sections (Panels)")]
    public GameObject[] sections; // Assign in Inspector
    public Button arrowButton;    // Assign the arrow UI Button

    private int currentIndex = 0;

    void Start()
    {
        // Validate setup
        if (sections == null || sections.Length == 0)
        {
            Debug.LogError("No UI sections assigned!");
            return;
        }

        if (arrowButton == null)
        {
            Debug.LogError("Arrow button not assigned!");
            return;
        }

        // Show only the first section
        ShowSection(currentIndex);

        // Add click listener
        arrowButton.onClick.AddListener(SwapSection);
    }

    void SwapSection()
    {
        // Move to next section
        currentIndex = (currentIndex + 1) % sections.Length;
        ShowSection(currentIndex);
    }

    void ShowSection(int index)
    {
        // Hide all sections
        for (int i = 0; i < sections.Length; i++)
        {
            if (sections[i] != null)
                sections[i].SetActive(i == index);
        }
    }
}

