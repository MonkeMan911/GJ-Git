using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThingsScript : MonoBehaviour
{
    public AudioManagerScript audioManagerScript;
    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        audioManagerScript.Load();
        audioS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
