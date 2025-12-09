using UnityEngine;
using UnityEngine.UI;

public class DiceSpriteChangerScript : MonoBehaviour
{
    public Sprite[] sprites;
    public Image uiImage;
    public SpriteRenderer spriteRenderer;

    private int currentIndex = 0;

    void Start()
    {
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned to SpriteChanger.");
            return;
        }

        UpdateSprite();
    }


    public void SetSpriteByIndex(int index)
    {
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogWarning("Sprite array is empty.");
            return;
        }

        if (index < 0 || index >= sprites.Length)
        {
            return;
        }

        currentIndex = index;
        UpdateSprite();
    }

    public void NextSprite()
    {
        currentIndex = (currentIndex + 1) % sprites.Length;
        UpdateSprite();
    }

    /// <summary>
    /// Moves to the previous sprite in the array (loops around).
    /// </summary>
    public void PreviousSprite()
    {
        currentIndex = (currentIndex - 1 + sprites.Length) % sprites.Length;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (uiImage != null)
            uiImage.sprite = sprites[currentIndex];

        if (spriteRenderer != null)
            spriteRenderer.sprite = sprites[currentIndex];
    }
}
