using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public int playerScore;
    public string playerMLevel;
    public int RDBMSScore;

    public int numDocs = 20;
    public int numRDBMS = 3;

    public int numShards = 1;
    public int docsInTank = 0;
    public int repsetSize = 1;



    public void UpdateScore(int score, int numShards)
    {

        var shards = GameObject.Find("Shards");
                
        switch(numShards)
        {
            case 1: 
            shards.transform.GetChild(0).gameObject.SetActive(true); 
            break;
 
            case 2:
            shards.transform.GetChild(1).gameObject.SetActive(true); 
            break; 

            case 3:
            shards.transform.GetChild(2).gameObject.SetActive(true); 
            break; 


        }





        docsInTank = score/numShards;
        
        switch(docsInTank)
        {
            case > 0 and <= 5:
                playerMLevel = "Free Tier";
                repsetSize = 1;
                break;
            case > 5 and <= 10:
                playerMLevel = "M2";
                repsetSize = 2;
                break;
            case > 10 and <= 20:
                playerMLevel = "M5";
                repsetSize = 5;
                break;
            case > 20 and <= 30:
                playerMLevel = "M10";
                repsetSize = 10;
                break;
            case > 30 and <= 40:
                playerMLevel = "M20";
                repsetSize = 20;
                break;
            case > 40 and <= 50:
                playerMLevel = "M30";
                repsetSize = 30;
                break;
            case > 50 and <= 60:
                playerMLevel = "M40";
                repsetSize = 40;
                break;
            case > 60 and <= 80:
                playerMLevel = "M60";
                repsetSize = 60;
                break;
            case > 80 and <= 100:
                playerMLevel = "M80";
                repsetSize = 80;
                break;
            case > 100 and <= 200:
                playerMLevel = "M200";
                repsetSize = 200;
                break;
            case > 200 and <= 400:
                playerMLevel = "M400";
                repsetSize = 400;
                break;
            default:
                playerMLevel = "Free Tier";
                repsetSize = 1;
                break;

            

        }
    }
}
