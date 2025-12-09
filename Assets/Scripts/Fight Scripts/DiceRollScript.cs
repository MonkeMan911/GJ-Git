using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollScript : MonoBehaviour
{
    public int diceOutcomeNumber;
    public int diceMaxNumber;
    [SerializeField] private DiceSpriteChangerScript diceSpriteChangerScript;
    void Start()
    {
        diceOutcomeNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (diceOutcomeNumber >= 0)
        {
            diceSpriteChangerScript.SetSpriteByIndex(diceOutcomeNumber - 1);
        }
    }
    public void DiceRoll() 
    { 
        diceOutcomeNumber = Random.Range(1, diceMaxNumber);
    }
}
