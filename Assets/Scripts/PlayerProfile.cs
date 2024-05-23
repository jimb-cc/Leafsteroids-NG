using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Profile
{
    public string Name;
    public string SessionID;
    public int Score;
    public int NumShards;
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
        CreatePlayerProfile();
    }

    public void GetPlayerProfileName(TMP_InputField name)
    {
        //string text = inputField.GetComponent<TMP_InputField>().text;
        pp.Name = name.text;
        Debug.Log("Player profile found: " + pp.Name + "!");
    }

    public void CreatePlayerProfile()
    {
        pp.Name = "PlayerName";
        pp.SessionID = "SessionID";
        pp.Score = 12345;
        pp.NumShards = 2;

        Debug.Log("Player profile found: " + pp.Name + "!");
        //get name from input field

    }
}
