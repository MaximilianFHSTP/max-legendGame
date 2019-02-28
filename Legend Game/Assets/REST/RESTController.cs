using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using REST;
using UnityEngine.UI;

public class RESTController : MonoBehaviour 
{
    private const float API_CHECK_MAXTIME = 3.0f; //3 Sekunden
    private float apiCheckCountdown = API_CHECK_MAXTIME;

    public GodUser godUser;

    public Text usernameText;

    public GameObject GameManager;

    private bool gameRunning = false;
    public void SetGameRunning(bool gameRunning) { this.gameRunning = gameRunning; }
    private bool appUserActive = false;

    void Start()
    {
        StartCoroutine(GetUser(CheckUserStatus));
    }

    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetUser(CheckUserStatus));
        }
    }

    /*
     * Diese Methode wird alle 3 Sekunden aufgerufen. Wenn der Benutzer vorher null war und dann nicht mehr ist ein neuer Benutzer beigetreten
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
        // Wenn der user null ist bedeutet das, dass er das Spiel verlassen hat!
        if (user.name == null && user.id == null)
        {
            Debug.Log("No user found");

            //CHECKEN ob ein lokaler User spielt!!
            GameManager.GetComponent<StartScreenBehaviour>().ToggleStartScreen(true);
            GameManager.GetComponent<StartScreenBehaviour>().ResetGame();

            usernameText.text = "Gast";

            return;
        }

        // Name des Benutzers
        Debug.Log("Name: " + user.name);

        // 1 = Englisch, 2 = Deutsch
        Debug.Log("Language: " + user.contentLanguageId);

        this.godUser = user;
        usernameText.text = this.godUser.name;

        if (gameRunning)
        {
            //Wenn das Spiel eh schon läuft
            //Countdown starten für Timeout
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
