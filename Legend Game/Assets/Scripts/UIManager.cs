using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;

public class UIManager : MonoBehaviour {

    public GameObject container_Choices;
    public GameObject container_Text;
    public Text text;
    public Text[] choices;

    public GameObject nextButton;
    public Text nextButtonText;

    public GameObject nextQuestionGameObject;
    public Text currentQuestionText;


	// Use this for initialization
	void Start () {
        container_Choices.SetActive(false);
        nextQuestionGameObject.SetActive(false);
        container_Text.SetActive(false);
        nextButton.SetActive(true);
	}

    public void ChangeLanguage(string language)
    {
        ResetDialogue();
        VD.SetCurrentLanguage(language);
        HandleNextAction();
    }

    public void ResetDialogue()
    {
        VD.EndDialogue();

        container_Choices.SetActive(false);
        nextQuestionGameObject.SetActive(false);
        container_Text.SetActive(false);
        nextButton.SetActive(true);

        text.text = "";
        nextButtonText.text = "START";
    }

    public void HandleNextAction()
    {
        if (!VD.isActive)
        {
            Begin();
            VD.Next();
        }
        else
        {
            VD.Next();
        }
    }

    void Begin()
    {
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
    }

    void UpdateUI(VD.NodeData data)
    {

        container_Text.SetActive(false);
        container_Choices.SetActive(false);
        nextQuestionGameObject.SetActive(false);

        if (data.isPlayer)
        {
            container_Choices.SetActive(true);
            nextQuestionGameObject.SetActive(true);
            nextButton.SetActive(false);

            for (int i = 0; i < choices.Length; i++)
            {
                if (i < data.comments.Length)
                {
                    choices[i].transform.parent.gameObject.SetActive(true);
                    choices[i].text = data.comments[i];
                }
                else
                {
                    choices[i].transform.parent.gameObject.SetActive(false);
                }
            }

        }
        else
        {
            container_Text.SetActive(true);
            nextButton.SetActive(true);
            text.text = data.comments[data.commentIndex];
        }
    }

    public void SetChoice(int choiceIndex)
    {
        VD.nodeData.commentIndex = choiceIndex;
        if (Input.GetMouseButtonUp(0))
        {
            VD.Next();
        }
    }

    public void SetNextQuestion(int nextQuestionID)
    {
        switch (nextQuestionID)
        {
            case 1:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich möchte...";
                    currentQuestionText.text = "Wer möchtest du sein?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I want to be...";
                    currentQuestionText.text = "Who do you want to be?";
                }
                break;
            case 2:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich bin...";
                    currentQuestionText.text = "Wo bist du gerade?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I am...";
                    currentQuestionText.text = "Where are you right now?";
                }
                break;
            case 3:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Zurück zum Anfang";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "Back to Start";
                    currentQuestionText.text = "";
                }
                break;
            case 4:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich habe...";
                    currentQuestionText.text = "Was hast du dabei?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I have...";
                    currentQuestionText.text = "What do you carry with you?";
                }
                break;
            case 5:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Hier ist noch...";
                    currentQuestionText.text = "Was ist noch hier?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "There is...";
                    currentQuestionText.text = "What else is here?";
                }
                break;
            case 6:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich würde gerne...";
                    currentQuestionText.text = "Was würdest du gerne tun?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I'd like to...";
                    currentQuestionText.text = "What would you like to do?";
                }
                break;
            case 7:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich habe doch etwas dabei...";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "On second thought...";
                    currentQuestionText.text = "";
                }
                break;
            case 8:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich muss...";
                    currentQuestionText.text = "Was musst du jetzt tun?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I have to...";
                    currentQuestionText.text = "What do you have to do now?";
                }
                break;
            case 9:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Dann möchte ich doch etwas anderes machen.";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "Then I want to do something else.";
                    currentQuestionText.text = "";
                }
                break;
            case 10:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich möchte doch etwas anderes machen.";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I want to do something else.";
                    currentQuestionText.text = "";
                }
                break;
            case 11:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich mache...";
                    currentQuestionText.text = "Was machst du?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I am...";
                    currentQuestionText.text = "What are you doing?";
                }
                break;
            case 12:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich würde gerne...";
                    currentQuestionText.text = "Was würdest du gerne tun?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I'd like to...";
                    currentQuestionText.text = "What would you like to do?";
                }
                break;
            case 13:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Das Wetter ist...";
                    currentQuestionText.text = "Wie ist das Wetter?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "The weather is...";
                    currentQuestionText.text = "What is the weather like?";
                }
                break;
            case 14:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich werde...";
                    currentQuestionText.text = "Was tust du jetzt?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I will...";
                    currentQuestionText.text = "What will you do now?";
                }
                break;
            case 15:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Weiter";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "Continue";
                    currentQuestionText.text = "";
                }
                break;
            case 16:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich möchte noch einmal spielen!";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I want to play again!";
                    currentQuestionText.text = "";
                }
                break;
            case 17:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Ich jage...";
                    currentQuestionText.text = "Jagst du alleine oder mit Jagdhunden?";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "I'm hunting...";
                    currentQuestionText.text = "Do you hunt alone or with hunting dogs?";
                }
                break;
            case 18:
                if (VD.currentLanguage.Equals("German"))
                {
                    nextButtonText.text = "Dann bin ich lieber...";
                    currentQuestionText.text = "";
                }
                else if (VD.currentLanguage.Equals("English"))
                {
                    nextButtonText.text = "Then I'd rather be...";
                    currentQuestionText.text = "";
                }
                break;
        }
    }

    void End(VD.NodeData data)
    {
        container_Choices.SetActive(false);
        container_Text.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    void OnDisable()
    {
        if(container_Text != null)
        {
            End(null);
        }
    }

}
