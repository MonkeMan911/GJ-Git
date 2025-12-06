using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Texture newSprite;
    [SerializeField] private Texture defaultSprite;

    [SerializeField] private RawImage rawImage;

    void Awake()
    {
        if (rawImage == null)
            rawImage = GetComponent<RawImage>();

        if (rawImage == null)
        {
            Debug.LogError("No RawImage found on this GameObject.");
        }
    }

    public void ChangeToNewTexture()
    {
        if (rawImage != null && newSprite != null)
        {
            rawImage.texture = newSprite;
        }
        else
        {
            Debug.LogWarning("RawImage or newSprite is missing.");
        }
    }

    public void RevertToDefaultTexture()
    {
        if (rawImage != null && defaultSprite != null)
        {
            rawImage.texture = defaultSprite;
        }
    }
}
