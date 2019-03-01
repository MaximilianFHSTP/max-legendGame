using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using REST;
using UnityEngine.UI;

public class RESTController : MonoBehaviour 
{
    private const float API_CHECK_MAXTIME = 2.0f; //2 Sekunden
    private float apiCheckCountdown = API_CHECK_MAXTIME;

    private const float SECONDS_TO_TIMEOUT = 10f;
    private float checkTimeout = SECONDS_TO_TIMEOUT;
    private const float SECONDS_TO_KICK = 10f;
    private float timeoutKick = SECONDS_TO_KICK;
    public GameObject timeoutCanvas;
    public Text timerHeading;
    public Text timerMessage1;
    public Text timerMessage2;
    public Text timerButtonText;
    public Text timerText;

    public GodUser godUser;

    public Text usernameText;

    public GameObject GameManager;

    private bool gameRunning = false;
    public void SetGameRunning(bool gameRunning) { this.gameRunning = gameRunning; }
    private bool appUserActive = false;

    void Start()
    {
        StartCoroutine(GetUser(CheckUserStatus));
        timeoutCanvas.SetActive(false);
    }

    void Update()
    {
        //Wenn das Spiel läuft, starte Timeout Counter
        if (gameRunning)
        {
            checkTimeout -= Time.deltaTime;
            if (checkTimeout <= 0)
            {
                //Timeout Canvas einblenden
                timeoutCanvas.SetActive(true);
                timeoutKick -= Time.deltaTime;
                timerText.text = Mathf.FloorToInt(timeoutKick).ToString();

                if (timeoutKick <= 0)
                {
                    //User raushauen, alles resetten
                    gameRunning = false;
                    appUserActive = false;
                    checkTimeout = SECONDS_TO_TIMEOUT;
                    timeoutKick = SECONDS_TO_KICK;
                    timeoutCanvas.SetActive(false);
                    GameManager.GetComponent<StartScreenBehaviour>().ToggleStartScreen(true);
                    GameManager.GetComponent<StartScreenBehaviour>().ResetGame();
                    usernameText.text = "Gast";
                    TransmitUserTimedOut();
                    this.godUser = null;
                }

            }
        }

        //In jedem Fall checke alle 2 Sekunden ob noch ein User da ist
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetUser(CheckUserStatus));
        }
    }

    public void UserStillHere()
    {
        timeoutCanvas.SetActive(false);
        checkTimeout = SECONDS_TO_TIMEOUT;
        timeoutKick = SECONDS_TO_KICK;
    }

    /*
     * Diese Methode wird alle 2 Sekunden aufgerufen. Wenn der Benutzer vorher null war und dann nicht mehr ist ein neuer Benutzer beigetreten
     * Umgekehrt, wenn ein Benutzer plötzlich null ist, hat er das Spiel wieder verlassen
     */
    IEnumerator GetUser(Action<GodUser> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://localhost:8100/unity/player"))
        {
            yield return req.Send();
            while (!req.isDone)
                yield return null;
            byte[] result = req.downloadHandler.data;
            string userJSON = System.Text.Encoding.Default.GetString(result);
            UserResponse response = JsonUtility.FromJson<UserResponse>(userJSON);
            onSuccess(response.godUser);
        }
    }

    public void CheckUserStatus(GodUser user)
    {
        Debug.Log(user.name);

        // Wenn der user null ist bedeutet das, dass er das Spiel verlassen hat!
        if (user.name == null && user.id == null)
        {
            Debug.Log("No user found");
            //Wenn vorher ein App User aktiv war und jetzt kein User mehr gefunden wird, ist kein App User mehr da
            if (appUserActive)
            {
                appUserActive = false;
                GameManager.GetComponent<StartScreenBehaviour>().ToggleStartScreen(true);
                GameManager.GetComponent<StartScreenBehaviour>().ResetGame();
                usernameText.text = "Gast";
            }

            //CHECKEN ob ein lokaler User spielt!!

            return;

        }

        //USER FOUND
        Debug.Log("User " + user.name + " found, language " + user.contentLanguageId + ".");
        this.godUser = user;
        usernameText.text = this.godUser.name;

        if (gameRunning)
        {
            //Wenn das Spiel eh schon läuft und ein User wird erkannt (oder ist eben noch da)
        }
        else
        {
            //Start Screen wegmachen, Spiel starten
            GameManager.GetComponent<StartScreenBehaviour>().ToggleStartScreen(false);
            GameManager.GetComponent<StartScreenBehaviour>().StartGame(godUser.contentLanguageId);
            appUserActive = true;
        }

    }

    /*
     * Ruf diese Methode auf wenn ein lokaler Benutzer das Spiel bedient (ohne Handy)
    */
    public IEnumerator TransmitLocalUserJoined()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://localhost:8100/unity/player/local/joined"))
        {
            yield return req.Send();
        }
    }

    /*
     * Ruf diese Methode auf wenn der lokale Benutzer das Spiel wieder verlassen hat
     */
    public IEnumerator TransmitLocalUserLeft()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://localhost:8100/unity/player/local/left"))
        {
            yield return req.Send();
        }
    }

    /*
     * Ruf diese Methode auf wenn der GoD Benutzer das Timeout erreicht hat (seit x Sekunden nichts mehr gedrückt hat)
     * Oder wenn er Logout Button gedrückt hat
     */
    public IEnumerator TransmitUserTimedOut()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://localhost:8100/unity/player/timeout"))
        {
            yield return req.Send();
        }
    }

    /*
     * Ruf diese Methode auf um für den Benutzer den Helm freizuschalten
     */
    public IEnumerator TransmitUnlockCoaHelmet()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://localhost:8100/unity/unlock/helmet"))
        {
            yield return req.Send();
        }
    }

    /*
    * Ruf diese Methode auf um für den Benutzer das Pferd Symbol freizuschalten
    */
    public IEnumerator TransmitUnlockCoaSymbol()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("http://localhost:8100/unity/unlock/symbol"))
        {
            yield return req.Send();
        }
    }
}
