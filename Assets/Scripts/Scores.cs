using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public int playerScore;
    public string playerMLevel;
    public int RDBMSScore;

    public int numDocs = 200;
    public int numRDBMS = 3;

    public int numShards = 1;
    public int docsInTank = 0;



    public void UpdateScore(int score, int numShards)
    {
        
        docsInTank = score/numShards;
        
        switch(docsInTank)
        {
            case > 0 and <= 5:
                playerMLevel = "Free Tier";
                break;
            case > 5 and <= 10:
                playerMLevel = "M2";
                break;
            case > 10 and <= 20:
                playerMLevel = "M5";
                break;
            case > 20 and <= 30:
                playerMLevel = "M10";
                break;
            case > 30 and <= 39:
                playerMLevel = "M20";
                break;
            case > 40 and <= 49:
                playerMLevel = "M30";
                break;
            case > 50 and <= 59:
                playerMLevel = "M40";
                break;
            case > 60 and <= 79:
                playerMLevel = "M60";
                break;
            case > 80 and <= 99:
                playerMLevel = "M80";
                break;
            case > 100 and <= 199:
                playerMLevel = "M200";
                break;
            case > 200 and <= 399:
                playerMLevel = "M400";
                break;
            default:
                playerMLevel = "Free Tier";
                break;

            

        }
    }
}
