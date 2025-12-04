using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEnemyScript : MonoBehaviour
{
    public float damageDone;
    [SerializeField] private DiceRollScript diceRollScript;
    private bool hasDamaged = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDamaged) return;
        {
            if (diceRollScript.diceOutcomeNumber >= 15)
            {
                damageDone += 3;
                hasDamaged = true;
            }
            if (diceRollScript.diceOutcomeNumber >= 10)
            {
                damageDone += 2;

            }
            if (diceRollScript.diceOutcomeNumber >= 5)
            {
                damageDone++;

            }
            else
                damageDone += 0;

        }
    }
    public void stuff() 
    {

    }
}
