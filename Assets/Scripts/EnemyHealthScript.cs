using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private PlayerDamageEnemyScript playerDamageEnemy;
    [SerializeField] private SpriteChanger spriteChanger;
    [SerializeField] private float EnemyHealth;    
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyTakeDamage() 
    {
        float damage = playerDamageEnemy.damageDone;
        if (damage > 0) 
        {
            EnemyHealth = EnemyHealth - damage;
            spriteChanger.ChangeToNewSprite();
        }
    }
}
