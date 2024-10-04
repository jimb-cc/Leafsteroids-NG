using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Profile
{
    public string name;
    public string sessionID;
    public string gameID;
    public string eventID;
    public int lastScore;
    public int lastGameTime;
}


public class PlayerProfile : MonoBehaviour
{

    public Profile pp = new Profile();


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        pp.name = "Player";
        pp.sessionID = "SessionID";
        pp.gameID = "GameID";
        pp.eventID = "EventID";
        pp.lastScore = 0;
        pp.lastGameTime = 0;
    }

    public void GetPlayerProfileName(TMP_InputField name)
    {
        //string text = inputField.GetComponent<TMP_InputField>().text;
        pp.name = name.text;
        pp.sessionID = "SessionID";
        pp.gameID = "GameID";
        Debug.Log(JsonUtility.ToJson(pp, true));
    }

    public void GetPlayerProfileEventID(string eventID)
    {
        //string text = inputField.GetComponent<TMP_InputField>().text;
        pp.eventID = eventID;
    }



}
