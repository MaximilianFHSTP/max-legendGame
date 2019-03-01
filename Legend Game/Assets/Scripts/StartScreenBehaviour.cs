using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenBehaviour : MonoBehaviour {

    public GameObject StartScreen;
    public StageManager StageManager;
    public UIManager DialogueManager;
    public RESTController rest;

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

    public void StartGame(int language)
    {
        DialogueManager.HandleNextAction();
        if (language == 2)
        {
            Debug.Log("Language switched to German");
            DialogueManager.ChangeLanguage("German");
        }else if (language == 1)
        {
            Debug.Log("Language switched to English");
            DialogueManager.ChangeLanguage("English");
        }
        rest.SetGameRunning(true);
    }

    public void StartGameAsLocalUser(int language)
    {
        rest.SetLocalUserActive(true);
        rest.LocalUserJoin();
        StartGame(language);
    }

    public void ResetGame()
    {
        DialogueManager.ResetDialogue();
        StageManager.ResetStage();
    }

}
