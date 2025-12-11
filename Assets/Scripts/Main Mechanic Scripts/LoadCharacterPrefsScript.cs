using UnityEngine;
using UnityEngine.UI; // Needed for Image

public class LoadCharacterPrefsScript : MonoBehaviour
{
    [Header("Available Character Prefabs")]
    public GameObject[] characterPrefabs; // Assign prefabs in Inspector

    [Header("Available Character Sprites")]
    public Sprite[] characterSprites; // Assign sprites in Inspector (same order as prefabs)

    [Header("Spawn Locations")]
    public Transform spawnPoint;     // Assign a spawn point in Inspector
    public Transform fightLocation;  // Assign a fight location in Inspector

    [Header("UI Display")]
    public Image characterImage;     // Assign ONE UI Image in Inspector

    [Header("Player Root Object")]
    public Transform playerRoot;     // Assign the Player object (camera rig or parent container)

    private const string PlayerPrefKey = "SelectedCharacter";

    void Start()
    {
        // Get saved character index
        int index = PlayerPrefs.GetInt(PlayerPrefKey, 0); // default to 0 if not set

        if (index < 0 || index >= characterPrefabs.Length)
        {
            Debug.LogError("Invalid character index saved!");
            return;
        }

        // --- Spawn the chosen character prefab ---
        GameObject player = Instantiate(characterPrefabs[index], spawnPoint.position, spawnPoint.rotation);

        // Parent it under the Player root so it moves with camera
        if (playerRoot != null)
        {
            player.transform.SetParent(playerRoot, worldPositionStays: true);
        }

        player.tag = "Player";

        // --- Spawn fighter separately (not parented to player) ---
        GameObject fighter = Instantiate(characterPrefabs[index], fightLocation.position, fightLocation.rotation);

        // --- Display the chosen character sprite ---
        if (characterImage != null && characterSprites.Length > index && characterSprites[index] != null)
        {
            characterImage.sprite = characterSprites[index];
        }
        else
        {
            Debug.LogWarning("No sprite assigned for character index: " + index);
        }
    }
}
