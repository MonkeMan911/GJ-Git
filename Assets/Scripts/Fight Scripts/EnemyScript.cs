using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private PlayerScript playerScript;
    [SerializeField] private HealthSpriteChanger[] spriteChangers;
    [SerializeField] private PannelHideNShowScript pannelHideNShow;
    [SerializeField] private GameObject enemy3D;
    [SerializeField] private Text enemyDamageToPlayer;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int EnemyHealth = 5;
    [SerializeField] private GameObject newPathButton;
    public bool IsDead => isDead;

    private bool damagedEnemy = false;
    private int pendingDamage = 0;

    void Awake()
    {
        isDead = false;
        EnemyHealth = Mathf.Clamp(EnemyHealth, 0, maxHealth);
        UpdateVisualsByHealthDiscrete();
    }

    void Update()
    {
        if (!damagedEnemy) return;

        ApplyDamage(pendingDamage);

        damagedEnemy = false;
        pendingDamage = 0;
    }

    public void FlagApplyDamageOnce(int amount)
    {
        damagedEnemy = true;
        pendingDamage = amount;
    }

    private void ApplyDamage(int amount)
    {
        int before = EnemyHealth;
        EnemyHealth = Mathf.Clamp(EnemyHealth - amount, 0, maxHealth);
        UpdateVisualsByHealthDiscrete();
        Debug.Log($"Enemy took {amount} damage. Health: {before} -> {EnemyHealth}");

        if (EnemyHealth <= 0)
        {
            HandleEnemyDeath();
        }
        else
        {
            TurnManager.Instance.EndPlayerTurn();
        }

    }

    private void UpdateVisualsByHealthDiscrete()
    {
        if (spriteChangers == null || spriteChangers.Length == 0) return;

        int count = Mathf.Min(spriteChangers.Length, maxHealth);

        for (int i = 0; i < count; i++)
        {
            var changer = spriteChangers[i];
            if (changer == null) continue;

            bool isHealthy = i < EnemyHealth;
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
        EnemyHealth = maxHealth;
    }

    public void EnemyAttack()
    {
        if (isDead) return;
        StartCoroutine(EnemyAttackPlayerWait());
    }


    private bool isDead = false;

    private void HandleEnemyDeath()
    {
        if (isDead) return;
        isDead = true;
        StopAllCoroutines();
        Debug.Log("Enemy died.");
        pannelHideNShow.TogglePanel(9);
        pannelHideNShow.DisableAllPanels();
        enemy3D.SetActive(false);
        StartCoroutine(NextLevelWait());
    }


    IEnumerator NextLevelWait()
    {
        yield return new WaitForSeconds(1);
        newPathButton.SetActive(true);
        Debug.Log("Hid All Comps And Switched to Next Phase");
    }

    IEnumerator EnemyAttackPlayerWait()
    {
        yield return new WaitForSeconds(1);

        if (isDead) yield break;

        int roll = Random.Range(1, 21);
        int enemyAttackDamage;

        if (roll >= 15) enemyAttackDamage = 3;
        else if (roll >= 10) enemyAttackDamage = 2;
        else if (roll >= 5) enemyAttackDamage = 1;
        else enemyAttackDamage = 0;

        Debug.Log($"Enemy rolled {roll}: damage = {enemyAttackDamage}");

        playerScript.FlagApplyDamageOnce(enemyAttackDamage);

        TurnManager.Instance.EndEnemyTurn();

        enemyDamageToPlayer.text = "- " + enemyAttackDamage.ToString();
    }
}
