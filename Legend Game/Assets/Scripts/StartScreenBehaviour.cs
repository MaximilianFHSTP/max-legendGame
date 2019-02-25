using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenBehaviour : MonoBehaviour {

    public GameObject StartScreen;
    public StageManager StageManager;
    public UIManager DialogueManager;

    public void ToggleStartScreen(bool startScreenVisible)
    {
        if (startScreenVisible)
        {
            StartScreen.SetActive(true);
        }
        else
        {
            StartScreen.SetActive(false);
        }
    }

    public void StartGame(string language)
    {
        DialogueManager.HandleNextAction();
        if (language.Equals("German"))
        {
            Debug.Log("Language switched to " + language);
            DialogueManager.ChangeLanguage(language);
        }else if (language.Equals("English"))
        {
            Debug.Log("Language switched to " + language);
            DialogueManager.ChangeLanguage(language);
        }
    }

    public void ResetGame()
    {
        DialogueManager.ResetDialogue();
        StageManager.ResetStage();
    }

}
