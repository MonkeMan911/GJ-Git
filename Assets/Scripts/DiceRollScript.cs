using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollScript : MonoBehaviour
{
    public Text diceOutcomeText;
    public int diceOutcomeNumber;
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
        diceOutcomeNumber = Random.Range(1, 6);
        diceOutcomeText.text = diceOutcomeNumber.ToString();
    }
}
