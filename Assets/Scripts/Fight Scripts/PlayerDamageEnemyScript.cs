using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageEnemyScript : MonoBehaviour
{
    public float damageDone;
    [SerializeField] private DiceRollScript diceRollScript;
    [SerializeField] private Text showDamageToEnemy;
    [SerializeField] private EnemyScript enemy; // assign in Inspector

    private bool hasDamaged = false;
    private bool hasRolled = false;

    // Call this from the Dice Roll button
    public void RollAndDamageEnemy()
    {
        if (hasDamaged || hasRolled)
        {
            Debug.Log("Already rolled this turn.");
            return;
        }

        if (diceRollScript == null)
        {
            Debug.LogWarning("DiceRollScript reference missing.");
            return;
        }

        int roll = diceRollScript.diceOutcomeNumber;

        if (roll >= 15) damageDone = 3f;
        else if (roll >= 10) damageDone = 2f;
        else if (roll >= 5) damageDone = 1f;
        else damageDone = 0f;

        Debug.Log($"Player rolled {roll}: damage = {damageDone}");
        showDamageToEnemy.text = "- " + damageDone.ToString();

        if (enemy != null)
            enemy.FlagApplyDamageOnce(Mathf.RoundToInt(damageDone));

        hasDamaged = true;
        hasRolled = true;

        TurnManager.Instance.EndPlayerTurn();
    }

    public void ResetDamageFlag() => hasDamaged = false;
    public void HasRolledPlayer() => hasRolled = false;
}
