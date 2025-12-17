using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TMPTextColorChanger : MonoBehaviour
{
    [Header("Assign all TMP_Text components here")]
    public TMP_Text[] textMeshProComponents;

    [Header("Highlight color when selected")]
    public string highlightColorCode = "#33FF57"; // green by default

    private Dictionary<TMP_Text, Color> originalColors = new Dictionary<TMP_Text, Color>();

    void Start()
    {
        // Save original colors for all assigned TMP_Text components
        foreach (TMP_Text tmp in textMeshProComponents)
        {
            if (tmp != null && !originalColors.ContainsKey(tmp))
            {
                originalColors[tmp] = tmp.color;
            }
        }
    }

    /// <summary>
    /// Call this from a button, passing in the TMP_Text you want to highlight
    /// </summary>
    public void OnButtonPressed(TMP_Text selectedText)
    {
        // Reset all texts to their original colors
        foreach (TMP_Text tmp in textMeshProComponents)
        {
            if (tmp != null && originalColors.ContainsKey(tmp))
            {
                tmp.color = originalColors[tmp];
            }
        }

        // Apply highlight color to the selected one
        if (selectedText != null)
        {
            selectedText.color = ColorFromHex(highlightColorCode);
        }
    }

    private Color ColorFromHex(string hex)
    {
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
