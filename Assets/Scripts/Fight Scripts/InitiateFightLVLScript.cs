using UnityEngine;

public class InitiateFightLVLScript : MonoBehaviour
{
    [SerializeField] private BoxCollider[] positions;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private CameraSwitcher cameraSwitcher;
    [SerializeField] PlayerThingsScript playerThingsScript;

    private bool hasSwitched = false;
    private void Start()
    {
        TeleportEnemyRandom(Random.Range(1, 9));
    }
    void Update()
    {
        if (hasSwitched) return; // stop checking once switched

        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].bounds.Contains(enemy.position) && positions[i].bounds.Contains(player.position))
            {
                playerThingsScript.audioS.Stop();
                cameraSwitcher.DisableCanvasAtIndex(0);
                cameraSwitcher.SwitchToNextCam();
                cameraSwitcher.EnableCanvasAtIndex(1);
                Debug.Log("Enemy + Player is inside collider index: " + i + " (" + positions[i].name + ")");
                hasSwitched = true;
                TurnManager.Instance.StartBattle();
                break;
            }
        }
    }
    public void TeleportEnemyRandom(int index)
    {
        // Use the collider’s actual center, not just its transform
        Vector3 targetPos = positions[index].bounds.center + offset;
        enemy.transform.position = targetPos;
    }

}
