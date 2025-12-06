using UnityEngine;
using UnityEngine.UI;

public class DiceTurnDisable : MonoBehaviour
{
    [SerializeField] private Button diceRollButton;

    void Update()
    {
        if (TurnManager.Instance == null || diceRollButton == null) return;

        diceRollButton.interactable = TurnManager.Instance.IsPlayerTurn();
    }
}
