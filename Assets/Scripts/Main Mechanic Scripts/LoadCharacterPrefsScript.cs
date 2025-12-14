using UnityEngine;
using UnityEngine.UI; 

public class LoadCharacterPrefsScript : MonoBehaviour
{
    [Header("Available Character Prefabs")]
    public GameObject[] characterPrefabs; 

    [Header("Available Character Sprites")]
    public Sprite[] characterSprites; 

    [Header("Spawn Locations")]
    public Transform spawnPoint;     
    public Transform fightLocation;  

    [Header("UI Display")]
    public Image characterImage;    

    [Header("Player Root Object")]
    public Transform playerRoot;     

    private const string PlayerPrefKey = "SelectedCharacter";

    void Start()
    {
        int index = PlayerPrefs.GetInt(PlayerPrefKey, 0); 

        if (index < 0 || index >= characterPrefabs.Length)
        {
            Debug.LogError("Invalid character index saved!");
            return;
        }


        GameObject player = Instantiate(characterPrefabs[index], spawnPoint.position, spawnPoint.rotation);

        // Parent it under the Player root so it moves with camera
        if (playerRoot != null)
        {
            player.transform.SetParent(playerRoot, worldPositionStays: true);
        }

        player.tag = "Player";


        GameObject fighter = Instantiate(characterPrefabs[index], fightLocation.position, fightLocation.rotation);


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
