using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;      
    [SerializeField] private Sprite defaultSprite;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on this GameObject.");
        }
    }

    public void ChangeToNewSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is missing.");
        }
    }

    public void RevertToDefaultSprite()
    {
        if (spriteRenderer != null && defaultSprite != null)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
