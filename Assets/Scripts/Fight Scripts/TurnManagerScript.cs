using UnityEngine;

public enum Turn
{
    Player,
    Enemy
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [SerializeField] private EnemyScript enemy;
    [SerializeField] private PlayerDamageEnemyScript playerDamage;

    public Turn currentTurn = Turn.Player;
    public bool battleStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currentTurn = Turn.Player;
    }

    public void StartBattle()
    {
        battleStarted = true;
        currentTurn = Turn.Player;
        Debug.Log("Battle started! Player's turn.");
    }

    public void EndPlayerTurn()
    {
        if (!battleStarted) return;

        currentTurn = Turn.Enemy;
        Debug.Log("Enemy's turn!");

        if (enemy != null && !enemy.IsDead) // ✅ only attack if alive
            enemy.EnemyAttack();
        else
            Debug.Log("Enemy is dead, skipping attack.");
    }



    public void EndEnemyTurn()
    {
        if (!battleStarted) return;

        currentTurn = Turn.Player;
        Debug.Log("Player's turn!");

        if (playerDamage != null)
        {
            playerDamage.HasRolledPlayer();
            playerDamage.ResetDamageFlag();
        }
        else
        {
            Debug.LogWarning("PlayerDamageEnemyScript reference missing in TurnManager.");
        }
    }

    public bool IsPlayerTurn() => battleStarted && currentTurn == Turn.Player;
    public bool IsEnemyTurn() => battleStarted && currentTurn == Turn.Enemy;
}
