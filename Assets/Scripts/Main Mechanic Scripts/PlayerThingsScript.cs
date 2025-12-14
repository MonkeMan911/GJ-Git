using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThingsScript : MonoBehaviour
{
    [SerializeField] AudioManagerScript audioManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        audioManagerScript.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
