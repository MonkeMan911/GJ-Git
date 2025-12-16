using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAndPrevSceneScript : MonoBehaviour
{
    [SerializeField] ResetTutorialTestScript resetTutorialTestScript;
    private int nextSceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadTutorial() 
    {
        resetTutorialTestScript.TutNotPlayedReset();
        resetTutorialTestScript.MonoNotPlayedReset();
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevelHard() 
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
