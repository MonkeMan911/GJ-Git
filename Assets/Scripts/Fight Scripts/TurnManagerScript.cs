using UnityEngine;

public enum Turn
{
    Player,
    Enemy
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance; // Singleton for easy access

    public Turn currentTurn = Turn.Player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void EndPlayerTurn()
    {
        currentTurn = Turn.Enemy;
        Debug.Log("Enemy's turn!");
        // Trigger enemy attack
        FindObjectOfType<EnemyScript>().EnemyAttack();
    }

    public void EndEnemyTurn()
    {
        currentTurn = Turn.Player;
        Debug.Log("Player's turn!");
        // Reset player roll flags so they can roll again
        FindObjectOfType<PlayerDamageEnemyScript>().HasRolledPlayer();
        FindObjectOfType<PlayerDamageEnemyScript>().ResetDamageFlag();
    }

    public bool IsPlayerTurn() => currentTurn == Turn.Player;
    public bool IsEnemyTurn() => currentTurn == Turn.Enemy;
}
