using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class MonologueFTScript : MonoBehaviour
{
    [SerializeField] private DisableGameObjectsScript dGameObjects;
    public GameObject FTBook;
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float[] lineDurations; // duration for each line
    public AudioSource audioSource;
    public float pauseAfterLine = 2f;

    // Events for each line (same length as lines[])
    public UnityEvent[] lineEvents;

    private int index;

    void Start()
    {
        if (PlayerPrefs.GetInt("MonologuePlayed", 0) >= 1)
        {
            audioSource.Stop();              // Stop any playing audio
            audioSource.enabled = false;     // Disable the AudioSource entirely
            TriggerAllEvents();
            gameObject.SetActive(false);     // Hide the monologue object
            StopAllCoroutines();
            return;
        }

        PlayerPrefs.SetInt("MonologuePlayed", 1);
        PlayerPrefs.Save();

        textComp.text = string.Empty;
        dGameObjects.Disable(0);
        dGameObjects.Disable(1);
        dGameObjects.Disable(2);
        dGameObjects.Disable(3);
        dGameObjects.Disable(4);
        dGameObjects.Disable(5);
        dGameObjects.Disable(6);
    }



    void TriggerAllEvents()
    {
        for (int i = 0; i < lineEvents.Length; i++)
        {
            if (lineEvents[i] != null)
            {
                lineEvents[i].Invoke();
            }
        }
    }
    public void StartMonologue()
    {
        index = 0;
        audioSource.Play();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        string currentLine = lines[index];
        float duration = lineDurations[index];
        float charDelay = duration / currentLine.Length;

        foreach (char c in currentLine.ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(charDelay);
        }

        // Trigger event for this line if assigned
        if (lineEvents != null && index < lineEvents.Length && lineEvents[index] != null)
        {
            lineEvents[index].Invoke();
        }

        // Pause audio for readability
        audioSource.Pause();
        yield return new WaitForSeconds(pauseAfterLine);

        NextLine();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            audioSource.UnPause();
            StartCoroutine(TypeLine());
        }
        else
        {
            audioSource.Stop();
            gameObject.SetActive(false);
        }
    }
}

