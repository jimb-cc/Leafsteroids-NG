using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

// fonts come from: https://fontesk.com/nice-tango-font/

public class endgameUImanager : MonoBehaviour
{
    public TextMeshProUGUI congratsUI;
    Scores scores;
    public PlayerProfile playerProfile;   

    // Start is called before the first frame update
    void Start()
    {
        playerProfile = FindObjectOfType<PlayerProfile>();
        scores = FindObjectOfType<Scores>();
        congratsUI.text = "Congrats " + playerProfile.pp.name + " you scored " + playerProfile.pp.lastScore + " in " +playerProfile.pp.lastGameTime  + " seconds!";
        Debug.Log(JsonUtility.ToJson(playerProfile.pp, true));
    }

}