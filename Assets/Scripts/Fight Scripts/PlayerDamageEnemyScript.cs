using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageEnemyScript : MonoBehaviour
{
    public float damageDone;
    [SerializeField] private DiceRollScript diceRollScript;
    [SerializeField] private Text showDamageToEnemy;
    private bool hasDamaged = false;
    private bool hasRolled = false;
    void Update()
    {
        if (hasDamaged) return;
        if (hasRolled) return;
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
        showDamageToEnemy.text = damageDone.ToString();
        hasDamaged = true;
        hasRolled = true;

        // End player turn
        TurnManager.Instance.EndPlayerTurn();
    }

    public void ResetDamageFlag() => hasDamaged = false;
    public void HasRolledPlayer() => hasRolled = false;
}
