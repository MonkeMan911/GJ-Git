using UnityEngine;

public class TeleportPlayerScript : MonoBehaviour
{
    public GameObject[] targets; 
    public Transform player;
    public void Teleport(int index)
    {
        if (targets != null && targets.Length > 0)
        {
            if (index >= 0 && index < targets.Length)
            {
                transform.position = targets[index].transform.position;
            }
            else
            {
                Debug.LogWarning("Teleport index out of range.");
            }
        }
        else
        {
            Debug.LogWarning("Targets array is empty or not assigned.");
        }
    }
}
