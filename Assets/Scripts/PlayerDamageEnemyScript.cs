using UnityEngine;

public class PlayerDamageEnemyScript : MonoBehaviour
{
    public float damageDone; // per-roll result
    
    [SerializeField] private DiceRollScript diceRollScript;
    private bool hasDamaged = false;
    void Update()
    {
        if (hasDamaged) return;
        if (diceRollScript == null)
        {
            Debug.LogWarning("DiceRollScript reference missing.");
            return;
        }

        int roll = diceRollScript.diceOutcomeNumber;

        // Per-roll damage (no accumulation)
        if (roll >= 15) damageDone = 3f;
        else if (roll >= 10) damageDone = 2f;
        else if (roll >= 5) damageDone = 1f;
        else damageDone = 0f;

        Debug.Log($"Roll {roll}: damage = {damageDone}");
        hasDamaged = true; // lock until reset
    }

    public void ResetDamageFlag() => hasDamaged = false;
}
