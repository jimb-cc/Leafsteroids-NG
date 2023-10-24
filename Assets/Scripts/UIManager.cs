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
        leftUI.text = "Left: " + scores.left.ToString();
    }


    public void UpdateScoreUI()
    {
        scoreUI.text = "Mongo: " + Scores.playerScore.ToString();
        leftUI.text = "Left: " + scores.left.ToString();
        lostUI.text = Scores.RDBMSScore.ToString() + " :RDBMS";

        if (scores.numShards>1) 
        { 
            cluster.text = scores.numShards.ToString() + " Shards of " + Scores.playerMLevel;
        }
        else
        {
            cluster.text = Scores.playerMLevel;
        }
    }
 
    public void UpdateRDBMSScoreUI()
    {
        lostUI.text = Scores.RDBMSScore.ToString() + " Lost";
        leftUI.text = "Left: " + scores.left.ToString();
    }

}
