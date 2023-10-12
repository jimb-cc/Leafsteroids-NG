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
public TextMeshProUGUI cluster;

public CollisionDetection colldec;
public DocGen numdocs;
Scores scores;



    // Start is called before the first frame update
    void Start()
    {
        scoreUI.text = "Score " + 0;
        lostUI.text =  0 + " Lost";
        cluster.text = "";
        scores = FindObjectOfType<Scores>();
    }


    public void UpdateScoreUI()
    {
        scoreUI.text = "Score " + scores.playerScore.ToString();

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
