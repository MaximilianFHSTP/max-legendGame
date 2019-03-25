using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class StageManager : MonoBehaviour {

    private string PlayerCharacter;

    public GameObject Wind1;
    public GameObject Wind2;
    public GameObject RewardStars;
    public GameObject Snow;
    public GameObject Sunrays;
    public Animator GoldenBackground;

    public GameObject Backgrounds;
    public GameObject Elderbush;
    public GameObject Boar;
    public GameObject BigBird1;
    public GameObject BigBird2;
    public GameObject SmallBird1;
    public GameObject SmallBird2;
    public GameObject SmallBird3;
    public GameObject Inhabitant1;
    public GameObject Inhabitant2;
    public GameObject Inhabitant3;
    public GameObject Horse;
    public GameObject Dog1;
    public GameObject Dog2;
    public GameObject Dog3;
    public GameObject NoblePerson;
    public GameObject Knight;
    public GameObject Foregrounds;
    public GameObject QuestionMark;

    public void ResetStage()
    {
        //Reset the Stage!
        Debug.Log("Bühne Reset");

        PlayerCharacter = "";

        Wind1.SetActive(false);
        Wind2.SetActive(false);
        Snow.SetActive(false);
        Sunrays.SetActive(false);
        RewardStars.SetActive(false);

        GoldenBackground.Play("Invisible");

        Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Blank");
        Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Blank");

        Elderbush.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Elderbush.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Ohne Schleier");
        Elderbush.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Elderbush.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Schleier Versteckt", true);
        Elderbush.SetActive(false);

        QuestionMark.GetComponent<SkeletonAnimation>().state.ClearTracks();
        QuestionMark.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        QuestionMark.SetActive(false);

        Boar.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Boar.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Boar.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", true);
        Boar.SetActive(false);

        BigBird1.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        BigBird1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
        BigBird1.SetActive(false);

        BigBird2.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        BigBird2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
        BigBird2.SetActive(false);

        SmallBird1.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        SmallBird1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
        SmallBird1.SetActive(false);

        SmallBird2.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        SmallBird2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
        SmallBird2.SetActive(false);

        SmallBird3.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        SmallBird3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 3", true);
        SmallBird3.SetActive(false);

        Inhabitant1.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Inhabitant1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
        Inhabitant1.SetActive(false);

        Inhabitant2.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Inhabitant2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
        Inhabitant2.SetActive(false);

        Inhabitant3.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Inhabitant3.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Inhabitant3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 3", true);
        Inhabitant3.SetActive(false);

        Horse.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", true);
        Horse.SetActive(false);

        Dog1.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Dog2.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Dog3.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Dog1.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Dog2.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Dog3.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Dog1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle Dog 1", true);
        Dog2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle Dog 2", true);
        Dog3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle Dog 3", true);
        Dog1.SetActive(false);
        Dog2.SetActive(false);
        Dog3.SetActive(false);

        NoblePerson.GetComponent<SkeletonAnimation>().state.ClearTracks();
        NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetSkin("default");
        NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetToSetupPose();
        NoblePerson.GetComponent<SkeletonAnimation>().state.Apply(NoblePerson.GetComponent<SkeletonAnimation>().skeleton);
        NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", true);
        NoblePerson.SetActive(false);

        Knight.GetComponent<SkeletonAnimation>().state.ClearTracks();
        Knight.GetComponent<SkeletonAnimation>().skeleton.SetSkin("default");
        Knight.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
        Knight.GetComponent<SkeletonAnimation>().skeleton.SetToSetupPose();
        Knight.GetComponent<SkeletonAnimation>().state.Apply(NoblePerson.GetComponent<SkeletonAnimation>().skeleton);
        Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", true);
        Knight.SetActive(false);

        Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Blank");
    }

    public void BACKTOSTART()
    {
        //This does nothing, it's just for the Dialog Visualization so I can easily copy and paste a connection to the start node!
        Debug.Log("Back To Start!");
    }

    public void UpdateStage(int updateCase)
    {

        //Evtl. jedes Mal dazuschreiben was bis jetzt gemacht wurde

        switch (updateCase)
        {
            case 0:
                Debug.Log("Adeliger erscheint");

                PlayerCharacter = "NoblePerson";
                NoblePerson.SetActive(true);
                NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", true);

                break;
            case 1:
                Debug.Log("Ritter erscheint");

                PlayerCharacter = "Knight";
                Knight.SetActive(true);
                Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", true);

                break;
            case 2:
                Debug.Log("Fragezeichen Animation abspielen");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().state.AddAnimation(1, "Fragezeichen", false, 0f);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.AddEmptyAnimation(1, 0f, 3f);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().state.AddAnimation(1, "Fragezeichen", false, 0f);
                    Knight.GetComponent<SkeletonAnimation>().state.AddEmptyAnimation(1, 0f, 3f);
                }

                break;
            case 3:
                Debug.Log("Waldhintergrund einblenden");

                Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Wald - Heiter");
                Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Wald - Heiter");
                Elderbush.SetActive(true);

                break;
            case 4:
                Debug.Log("Pfeil und Bogen einblenden");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Jagen");
                    NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
                    NoblePerson.GetComponent<SkeletonAnimation>().state.Apply(NoblePerson.GetComponent<SkeletonAnimation>().skeleton);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Jagen");
                    Knight.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
                    Knight.GetComponent<SkeletonAnimation>().state.Apply(NoblePerson.GetComponent<SkeletonAnimation>().skeleton);
                }
                break;
            case 5:
                Debug.Log("Muschel, Hut und Stab einblenden");
                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Pilgern");
                    NoblePerson.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
                    NoblePerson.GetComponent<SkeletonAnimation>().state.Apply(NoblePerson.GetComponent<SkeletonAnimation>().skeleton);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Pilgern");
                    Knight.GetComponent<SkeletonAnimation>().skeleton.SetSlotsToSetupPose();
                    Knight.GetComponent<SkeletonAnimation>().state.Apply(NoblePerson.GetComponent<SkeletonAnimation>().skeleton);
                }

                break;
            case 6:
                Debug.Log("Hunde einblenden");

                Dog1.SetActive(true);
                Dog1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle Dog 1", true);
                Dog2.SetActive(true);
                Dog2.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Idle Dog 2", true, 1.5f);
                Dog3.SetActive(true);
                Dog3.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Idle Dog 3", true, 0.6f);

                break;
            case 7:
                Debug.Log("Waldvögel einblenden");

                BigBird1.SetActive(true);
                BigBird1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
                BigBird2.SetActive(true);
                BigBird2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
                SmallBird1.SetActive(true);
                SmallBird1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
                SmallBird2.SetActive(true);
                SmallBird2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
                SmallBird3.SetActive(true);
                SmallBird3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 3", true);

                break;
            case 8:
                Debug.Log("Eber einblenden");

                Boar.SetActive(true);
                Boar.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Attack", true);

                break;
            case 9:
                Debug.Log("Char auf Pferd setzen");

                Horse.SetActive(true);
                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle auf Pferd", true);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle auf Pferd", true);
                }

                break;
            case 10:
                Debug.Log("Landessprache lernen");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Weggehen", false);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Weggehen", false);
                }

                break;
            case 11:
                Debug.Log("Char wird auf Hollunderstrauch aufgehängt");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    Inhabitant3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Aufhaengen", false);
                    Inhabitant3.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen Ende", true, 0f);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Aufhaengen", false);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Aufgehaengt", true, 0f);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Inhabitant3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Aufhaengen", false);
                    Inhabitant3.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen Ende", true, 0f);
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Aufhaengen", false);
                    Knight.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Aufgehaengt", true, 0f);
                }

                break;
            case 12:
                Debug.Log("Ins heilige Land pilgern");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    Inhabitant1.SetActive(true);
                    Inhabitant1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
                    Inhabitant2.SetActive(true);
                    Inhabitant2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
                    Inhabitant3.SetActive(true);
                    Inhabitant3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 3", true);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Pilgern", false);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Bei Busch Stehen", true, 0f);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Inhabitant1.SetActive(true);
                    Inhabitant1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 1", true);
                    Inhabitant2.SetActive(true);
                    Inhabitant2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 2", true);
                    Inhabitant3.SetActive(true);
                    Inhabitant3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle 3", true);
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Pilgern", false);
                    Knight.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Bei Busch Stehen", true, 0f);
                }

                break;
            case 13:
                Debug.Log("Jagd-Animation auf Charakter");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Jagd", false);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Jagd", false);
                }

                break;
            case 14:
                Debug.Log("Fromm-Sein-Animation auf Charakter (Steckt Waffe auf die Seite)");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Fromm", false);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Fromm", false);
                }

                break;
            case 15:
                Debug.Log("Suchen-Animation auf Charakter");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Suche", false);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Suche", false);
                }

                break;
            case 16:

                Debug.Log("Winter Wetter einschalten, Hollunderbusch ausblenden");
                Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Wald - Winterlich Kalt");
                Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Wald - Winterlich Kalt");
                Snow.SetActive(true);
                Elderbush.SetActive(false);

                break;
            case 17:

                Debug.Log("Windiges Wetter einschalten");
                Wind1.SetActive(true);
                Wind2.SetActive(true);
                Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Wald - Windig");
                Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Wald - Heiter");

                break;
            case 18:
                Debug.Log("Charakter schießt auf Eber.");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    Boar.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Idle", false);
                    Boar.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Die", true, 0f);
                    Boar.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Erlegt", true, 0f);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Erlegen", false);
                    NoblePerson.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Erlegt", true, 0f);
                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Boar.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Die", false);
                    Boar.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Erlegt", true, 0f);
                    Knight.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Erlegen", false);
                    Knight.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Erlegt", true, 0f);
                }

                break;
            case 19:
                Debug.Log("Hunde schlagen an und rennen zum Hollunderbusch, Schleier erscheint im Busch.");

                if (PlayerCharacter.Equals("NoblePerson"))
                {
                    Boar.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Away", false);
                    Boar.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Away", true, 0f);

                    Dog1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Dog 1", false);
                    Dog1.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen  Dog 1", true, 0f);
                    Dog2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Dog 2", false);
                    Dog2.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen  Dog 2", true, 0f);
                    Dog3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Dog 3", false);
                    Dog3.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen  Dog 3", true, 0f);

                    Elderbush.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Schleier");
                    Elderbush.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Schleier Erscheint", false);
                    Elderbush.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Schleier Da", true, 0f);

                }
                else if (PlayerCharacter.Equals("Knight"))
                {
                    Boar.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Away", false);
                    Boar.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Away", true, 0f);

                    Dog1.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Dog 1", false);
                    Dog1.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen  Dog 1", true, 0f);
                    Dog2.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Dog 2", false);
                    Dog2.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen  Dog 2", true, 0f);
                    Dog3.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Run Dog 3", false);
                    Dog3.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Rumstehen  Dog 3", true, 0f);

                    Elderbush.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Schleier");
                    Elderbush.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "Schleier Erscheint", false);
                    Elderbush.GetComponent<SkeletonAnimation>().state.AddAnimation(0, "Schleier Da", true, 0f);
                }

                break;
            case 20:

                Debug.Log("LEGENDE GESCHAFFEN, YAY! 8D");
                RewardStars.SetActive(true);
                GoldenBackground.SetTrigger("Appear");

                break;
            case 21:

                Debug.Log("Sonnenstrahlen einblenden");
                Sunrays.SetActive(true);

                break;
            case 22:

                Debug.Log("Fragezeichen-Animation alleine starten");
                QuestionMark.SetActive(true);
                QuestionMark.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "QuestionMark", false);

                break;
            case 23:

                Debug.Log("Lichtung Heiter und Hollunderbusch einblenden");
                Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Lichtung - Heiter");
                Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Lichtung - Heiter");
                Elderbush.SetActive(true);

                break;
            case 24:

                Debug.Log("Lichtung Winter Wetter einschalten, Hollunderbusch ausblenden");
                Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Lichtung - Winterlich Kalt");
                Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Lichtung - Winterlich Kalt");
                Snow.SetActive(true);
                Elderbush.SetActive(false);

                break;
            case 25:

                Debug.Log("Lichtung - Windiges Wetter einschalten");
                Wind1.SetActive(true);
                Wind2.SetActive(true);
                Backgrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Lichtung - Windig");
                Foregrounds.GetComponent<SkeletonAnimation>().skeleton.SetSkin("Lichtung - Windig");

                break;
        }

    }

    private void DisableRewardStars()
    {
        RewardStars.SetActive(false);
    }

}
