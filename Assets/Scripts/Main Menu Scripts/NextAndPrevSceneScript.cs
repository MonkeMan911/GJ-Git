using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAndPrevSceneScript : MonoBehaviour
{
    [SerializeField] ResetTutorialTestScript resetTutorialTestScript;
    [SerializeField] private string[] randomLevels;

    private string lastLoadedScene = null;

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

    public void LoadNextLevel(string chooseScene)
    {
        SceneManager.LoadScene(chooseScene);
    }

    public void LoadRandomLevel()
    {
        if (randomLevels.Length == 0)
        {
            Debug.LogWarning("No random levels assigned in Inspector!");
            return;
        }

        if (randomLevels.Length == 1)
        {
            SceneManager.LoadScene(randomLevels[0]);
            return;
        }

        // Build a list of candidates excluding the last loaded scene
        List<string> candidates = new List<string>(randomLevels);
        if (lastLoadedScene != null)
        {
            candidates.Remove(lastLoadedScene);
        }

        int index = Random.Range(0, candidates.Count);
        string randomScene = candidates[index];

        lastLoadedScene = randomScene;
        Debug.Log("Loading random scene: " + randomScene);
        SceneManager.LoadScene(randomScene);
    }
}
