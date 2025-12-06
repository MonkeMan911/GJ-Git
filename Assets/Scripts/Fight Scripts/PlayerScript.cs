using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private PlayerDamageEnemyScript playerDamageEnemy;
    [SerializeField] private SpriteChanger[] spriteChangers;
    [SerializeField] private PannelHideNShowScript pannelHideNShow;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int PlayerHealth = 5;

    private bool damagedPlayer = false;

    void Awake()
    {
        PlayerHealth = Mathf.Clamp(PlayerHealth, 0, maxHealth);
        UpdateVisualsByHealthDiscrete();
    }

    void Update()
    {
        if (!damagedPlayer) return;

        float damage = playerDamageEnemy.damageDone;

        if (damage > 0f)
        {
            ApplyDamage(Mathf.RoundToInt(damage));
        }
        else
        {
            Debug.Log("No damage this roll.");
        }

        // Reset for next roll
        damagedPlayer = false;
        playerDamageEnemy.damageDone = 0f;
        playerDamageEnemy.ResetDamageFlag();
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

    /// Updates UI segments left-to-right:
    /// indices [0..EnemyHealth-1] = healthy, [EnemyHealth..maxHealth-1] = damaged.
    private void UpdateVisualsByHealthDiscrete()
    {
        if (spriteChangers == null || spriteChangers.Length == 0) return;

        // Ensure array length matches maxHealth (recommended).
        int count = Mathf.Min(spriteChangers.Length, maxHealth);

        for (int i = 0; i < count; i++)
        {
            var changer = spriteChangers[i];
            if (changer == null) continue;

            bool isHealthy = i < PlayerHealth;

            // If defaultSprite is HEALTHY and newSprite is DAMAGED:
            if (isHealthy) changer.RevertToDefaultTexture(); else changer.ChangeToNewTexture();

            // If your setup is the opposite (newSprite = healthy), swap the calls:
            // if (isHealthy) changer.ChangeToNewTexture(); else changer.RevertToDefaultTexture();
        }

        // Optional: if array longer than maxHealth, mark extras as damaged or keep default
        for (int i = maxHealth; i < spriteChangers.Length; i++)
            spriteChangers[i]?.RevertToDefaultTexture(); // or ChangeToNewTexture() per your design
    }

    public void FlagApplyDamageOnce() => damagedPlayer = true;

    public void RevertAllToDefault()
    {
        if (spriteChangers == null) return;
        foreach (var changer in spriteChangers)
            changer?.RevertToDefaultTexture();
        PlayerHealth = maxHealth;
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player died.");
        pannelHideNShow.TogglePanel(10);
        pannelHideNShow.DisableAllPanels();
        StartCoroutine(ResetLevelWait());
    }
    IEnumerator ResetLevelWait()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Hid All Comps And Switched to Next Phase");
    }
}
