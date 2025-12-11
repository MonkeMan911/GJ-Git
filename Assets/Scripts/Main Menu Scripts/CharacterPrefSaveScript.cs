using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterOption
{
    public string name;               // For clarity in Inspector
    public int id;                    // ID saved in PlayerPrefs
    public GameObject modelPrefab;    // Assign the prefab/model in Inspector
    public Sprite characterSprite;    // Assign a sprite (portrait/icon) in Inspector
}

public class CharacterPrefSaveScript : MonoBehaviour
{
    [Header("Available Characters")]
    public CharacterOption[] characters; // Assign in Inspector

    [Header("Currently Selected Character")]
    [SerializeField] private int currentCharacterIndex = 0;

    [Header("UI Buttons")]
    public Button[] characterButtons; // Assign buttons in Inspector

    public const string PlayerPrefKey = "SelectedCharacter";

    private GameObject activeModelInstance;

    void Start()
    {
        // Load saved character index if it exists
        if (PlayerPrefs.HasKey(PlayerPrefKey))
        {
            currentCharacterIndex = PlayerPrefs.GetInt(PlayerPrefKey);
        }
        else
        {
            currentCharacterIndex = 0; // default to first
            PlayerPrefs.SetInt(PlayerPrefKey, currentCharacterIndex);
        }

        Debug.Log("Loaded Character Index: " + currentCharacterIndex);

        // Hook up buttons
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i; // capture loop variable
            characterButtons[i].onClick.AddListener(() => ChoosePlayer(index));
        }

        // Spawn the saved character model and update sprite
        SpawnCharacterModel(currentCharacterIndex);
    }

    public void ChoosePlayer(int index)
    {
        if (index < 0 || index >= characters.Length)
        {
            Debug.LogError("Invalid character index!");
            return;
        }

        currentCharacterIndex = index;

        // Save to PlayerPrefs
        PlayerPrefs.SetInt(PlayerPrefKey, currentCharacterIndex);
        PlayerPrefs.Save();

        Debug.Log("Character chosen: " + characters[index].name);

        // Spawn the chosen model and update sprite
        SpawnCharacterModel(index);
    }

    private void SpawnCharacterModel(int index)
    {
        // Destroy previous instance if exists
        if (activeModelInstance != null)
        {
            Destroy(activeModelInstance);
        }

        // Instantiate new model prefab
        if (characters[index].modelPrefab != null)
        {
            activeModelInstance = Instantiate(characters[index].modelPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefab assigned for character: " + characters[index].name);
        }
    }

    public CharacterOption GetCurrentCharacter()
    {
        return characters[currentCharacterIndex];
    }
}
