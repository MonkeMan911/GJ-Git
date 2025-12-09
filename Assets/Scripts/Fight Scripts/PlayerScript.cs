using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private HealthSpriteChanger[] spriteChangers;
    [SerializeField] private PannelHideNShowScript pannelHideNShow;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int PlayerHealth = 5;

    private bool damagedPlayer = false;
    private int pendingDamage = 0;

    void Awake()
    {
        PlayerHealth = Mathf.Clamp(PlayerHealth, 0, maxHealth);
        UpdateVisualsByHealthDiscrete();
    }

    void Update()
    {
        if (!damagedPlayer) return;

        ApplyDamage(pendingDamage);

        // Reset
        damagedPlayer = false;
        pendingDamage = 0;
    }

    public void FlagApplyDamageOnce(int amount)
    {
        damagedPlayer = true;
        pendingDamage = amount;
    }

    private void ApplyDamage(int amount)
    {
        int before = PlayerHealth;
        PlayerHealth = Mathf.Clamp(PlayerHealth - amount, 0, maxHealth);
        UpdateVisualsByHealthDiscrete();
        Debug.Log($"Player took {amount} damage. Health: {before} -> {PlayerHealth}");

        if (PlayerHealth <= 0)
            HandlePlayerDeath();
    }

    private void UpdateVisualsByHealthDiscrete()
    {
        if (spriteChangers == null || spriteChangers.Length == 0) return;

        int count = Mathf.Min(spriteChangers.Length, maxHealth);

        for (int i = 0; i < count; i++)
        {
            var changer = spriteChangers[i];
            if (changer == null) continue;

            bool isHealthy = i < PlayerHealth;
            if (isHealthy) changer.RevertToDefaultTexture(); else changer.ChangeToNewTexture();
        }

        for (int i = maxHealth; i < spriteChangers.Length; i++)
            spriteChangers[i]?.RevertToDefaultTexture();
    }

    public void RevertAllToDefault()
    {
        if (spriteChangers == null) return;
        foreach (var changer in spriteChangers)
            changer?.RevertToDefaultTexture();
        PlayerHealth = maxHealth;
    }

    private bool isDead = false;

    private void HandlePlayerDeath()
    {
        if (isDead) return; // Prevent multiple calls
        isDead = true;

        Debug.Log("Player died.");
        pannelHideNShow.TogglePanel(10);
        pannelHideNShow.DisableAllPanels();
        StartCoroutine(ResetLevelWait());
    }


    IEnumerator ResetLevelWait()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Hid All Comps And Switched to Next Phase");
        SceneManager.LoadScene(0);
    }
}
