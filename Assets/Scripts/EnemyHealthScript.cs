using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private PlayerDamageEnemyScript playerDamageEnemy;
    [SerializeField] private SpriteChanger[] spriteChangers; // assign in Inspector

    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float EnemyHealth = 5f;

    private bool damagedEnemy = false;

    void Awake()
    {
        // Make sure starting health is valid
        EnemyHealth = Mathf.Clamp(EnemyHealth, 0f, maxHealth);
    }

    void Update()
    {
        if (!damagedEnemy) return;

        float damage = playerDamageEnemy.damageDone;

        if (damage > 0f)
        {
            ApplyDamage(damage);
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

    private void ApplyDamage(float amount)
    {
        float before = EnemyHealth;

        // 1) Subtract damage and clamp
        EnemyHealth = Mathf.Max(EnemyHealth - amount, 0f);

        // 2) >>> PLACE YOUR TWO LINES HERE <<<
        // Map current health to the proper UI index and change only that one
        int currentSpriteIndex = HealthToIndex(EnemyHealth, maxHealth, spriteChangers.Length);
        ApplyChangeToIndex(currentSpriteIndex);

        Debug.Log($"Enemy took {amount} damage. Health: {before} -> {EnemyHealth}");

        if (EnemyHealth <= 0f)
        {
            HandleDeath();
        }
    }

    /// Maps health percentage to an index in spriteChangers.
    /// 100% health -> index 0; 0% health -> index count-1
    private int HealthToIndex(float health, float max, int count)
    {
        if (count <= 0) return -1;

        float damagedFraction = 1f - (health / max);           // 0 at full, 1 at zero health
        int idx = Mathf.Clamp(Mathf.FloorToInt(damagedFraction * count), 0, count - 1);
        return idx;
    }

    private void ApplyChangeToIndex(int index)
    {
        if (spriteChangers == null || spriteChangers.Length == 0) return;
        if (index < 0 || index >= spriteChangers.Length) return;

        var changer = spriteChangers[index];
        changer?.ChangeToNewTexture();
    }

    public void FlagApplyDamageOnce() => damagedEnemy = true;

    public void RevertAllToDefault()
    {
        if (spriteChangers == null) return;
        foreach (var changer in spriteChangers)
            changer?.RevertToDefaultTexture();
    }

    private void HandleDeath()
    {
        // TODO: disable collider, play death animation, destroy, etc.
        Debug.Log("Enemy died.");
    }
}
