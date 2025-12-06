
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private PlayerDamageEnemyScript playerDamageEnemy;
    [SerializeField] private SpriteChanger[] spriteChangers;
    [SerializeField] private CanvasDisabler canvasDisabler;
    [SerializeField] private int maxHealth = 5;              
    [SerializeField] private int EnemyHealth = 5;            

    private bool damagedEnemy = false;

    void Awake()
    {
        EnemyHealth = Mathf.Clamp(EnemyHealth, 0, maxHealth);
        UpdateVisualsByHealthDiscrete(); 
    }

    void Update()
    {
        if (!damagedEnemy) return;

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
        damagedEnemy = false;
        playerDamageEnemy.damageDone = 0f;
        playerDamageEnemy.ResetDamageFlag();
    }

    private void ApplyDamage(int amount)
    {
        int before = EnemyHealth;
        EnemyHealth = Mathf.Clamp(EnemyHealth - amount, 0, maxHealth);
        UpdateVisualsByHealthDiscrete();
        Debug.Log($"Enemy took {amount} damage. Health: {before} -> {EnemyHealth}");

        if (EnemyHealth <= 0)
            HandleDeath();
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

            bool isHealthy = i < EnemyHealth;

            // If defaultSprite is HEALTHY and newSprite is DAMAGED:
            if (isHealthy) changer.RevertToDefaultTexture(); else changer.ChangeToNewTexture();

            // If your setup is the opposite (newSprite = healthy), swap the calls:
            // if (isHealthy) changer.ChangeToNewTexture(); else changer.RevertToDefaultTexture();
        }

        // Optional: if array longer than maxHealth, mark extras as damaged or keep default
        for (int i = maxHealth; i < spriteChangers.Length; i++)
            spriteChangers[i]?.RevertToDefaultTexture(); // or ChangeToNewTexture() per your design
    }

    public void FlagApplyDamageOnce() => damagedEnemy = true;

    public void RevertAllToDefault()
    {
        if (spriteChangers == null) return;
        foreach (var changer in spriteChangers)
            changer?.RevertToDefaultTexture();
        EnemyHealth = maxHealth;
    }

    private void HandleDeath()
    {
        Debug.Log("Enemy died.");
        canvasDisabler.EnableAtIndex(10);
    }
}
