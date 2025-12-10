using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObjectsScript : MonoBehaviour
{
    public GameObject[] gameObjects;

    public void Disable(int index)
    {
        foreach (GameObject go in gameObjects) 
        {
            go.SetActive(false);
        }
    }
    public void Enable(int index)
    {
        foreach (GameObject go in gameObjects) 
        {
            go.SetActive(true);
        }
    }
}
