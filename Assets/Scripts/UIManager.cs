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


    public void UpdateScore(int score)
    {
        scoreUI.text = "Score " + score.ToString();
 
        switch(score)
        {
            case > 0 and <= 5:
                cluster.text="";
                break;
            case > 5 and <= 10:
                cluster.text="M5";
                break;
            case > 10 and <= 20:
                cluster.text="M10";
                break;
            case > 20 and <= 30:
                cluster.text="M20";
                break;
            case > 30 and <= 39:
                cluster.text="M30";
                break;
            case > 40 and <= 49:
                cluster.text="M40";
                break;
            case > 50 and <= 59:
                cluster.text="M50";
                break;
            case > 60 and <= 79:
                cluster.text="M60";
                break;
            case > 80 and <= 99:
                cluster.text="M80";
                break;
            case > 100 and <= 199:
                cluster.text="M100";
                break;
            case > 200 and <= 399:
                cluster.text="M200";
                break;
            default:
                cluster.text="";
                break;
        }
 
 
    }


    public void UpdateRDBMSScore()
    {
        lostUI.text = scores.RDBMSScore.ToString() + " Lost";
    }

    public void Test()
    {
        Debug.Log("Arrived in uiman");
    }

}
