using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollScript : MonoBehaviour
{
    public Text diceOutcomeText;
    public int diceOutcomeNumber;
    public int diceMaxNumber;
    void Start()
    {
        diceOutcomeNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DiceRoll() 
    { 
        diceOutcomeNumber = Random.Range(1, diceMaxNumber);
        diceOutcomeText.text = diceOutcomeNumber.ToString();
    }
}
