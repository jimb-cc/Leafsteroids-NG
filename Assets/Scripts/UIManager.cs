using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


// fonts come from: https://fontesk.com/nice-tango-font/

public class UIManager : MonoBehaviour
{

public TextMeshProUGUI scoreUI;
public TextMeshProUGUI lostUI;
public TextMeshProUGUI leftUI;
public TextMeshProUGUI cluster;

Scores scores;



    // Start is called before the first frame update
    void Start()
    {
        scoreUI.text = "Mongo: " + 0;
        lostUI.text =  0 + " :RDBMS";
        cluster.text = "";
        scores = FindObjectOfType<Scores>();
    }


    public void UpdateScoreUI()
    {
        scoreUI.text = "Mongo: " + scores.playerScore.ToString();
        leftUI.text = "Left: " + scores.left.ToString();
        lostUI.text = scores.RDBMSScore.ToString() + " :RDBMS";

        if (scores.numShards>1) 
        { 
            cluster.text = scores.numShards.ToString() + " Shards of " + scores.playerMLevel;
        }
        else
        {
            cluster.text = scores.playerMLevel;
        }
    }
 
    public void UpdateRDBMSScoreUI()
    {
        lostUI.text = scores.RDBMSScore.ToString() + " Lost";
    }

}
