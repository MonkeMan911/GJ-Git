using UnityEngine;

public class InitiateFightScript : MonoBehaviour
{
    [SerializeField] private BoxCollider[] positions;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform player;
    [SerializeField] private CameraSwitcher cameraSwitcher;
    [SerializeField] private MonologueFTScript monologueFTScript;

    private bool hasSwitched = false;

    void Update()
    {
        if (hasSwitched) return; // stop checking once switched

        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].bounds.Contains(enemy.position) && positions[i].bounds.Contains(player.position))
            {
                cameraSwitcher.DisableCanvasAtIndex(0);
                cameraSwitcher.SwitchToNextCam();
                cameraSwitcher.EnableCanvasAtIndex(1);
                Debug.Log("Enemy + Player is inside collider index: " + i + " (" + positions[i].name + ")");
                hasSwitched = true;
                TurnManager.Instance.StartBattle();

                // Check PlayerPrefs flag instead of local bool
                if (PlayerPrefs.GetInt("MonologuePlayed", 0) == 0)
                {
                    monologueFTScript.FTBook.SetActive(true);
                    monologueFTScript.StartMonologue();
                }
                break;
            }
        }
    }
}
