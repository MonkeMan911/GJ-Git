using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEnemyScript : MonoBehaviour
{
    public float damageDone;
    [SerializeField] private DiceRollScript diceRollScript;

    // Make this non-serialized so the Inspector can’t accidentally keep it true.
    private bool hasDamaged = false;

    void Update()
    {
        // Skip once we've already applied damage this roll/frame
        if (hasDamaged) return;

        // Guard against a missing reference to diceRollScript
        if (diceRollScript == null)
        {
            Debug.LogWarning("DiceRollScript reference is missing on PlayerDamageEnemyScript.");
            return;
        }

        int roll = diceRollScript.diceOutcomeNumber;
        float before = damageDone;

        if (roll >= 15)
        {
            damageDone += 3f;
            Debug.Log($"Roll {roll}: +3 damage (total {before} -> {damageDone})");
        }
        else if (roll >= 10)
        {
            damageDone += 2f;
            Debug.Log($"Roll {roll}: +2 damage (total {before} -> {damageDone})");
        }
        else if (roll >= 5)
        {
            damageDone += 1f;
            Debug.Log($"Roll {roll}: +1 damage (total {before} -> {damageDone})");
        }
        else
        {
            // No damage
            Debug.Log($"Roll {roll}: +0 damage (total {before} -> {damageDone})");
        }

        hasDamaged = true; // prevent re-applying until reset
    }

    // Call this when a NEW dice roll starts or completes, before evaluating again.
    public void ResetDamageFlag()
    {
        hasDamaged = false;
    }
}
