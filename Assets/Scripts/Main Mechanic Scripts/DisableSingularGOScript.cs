using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSingularGOScript : MonoBehaviour
{
    public GameObject gO;
    public void DisableSingleObject() 
    {
        gO.SetActive(false);
    }
    public void EnableSingleObject() 
    {
        gO.SetActive(true);
    }
}
