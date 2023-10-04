using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public int playerScore;
    public int playerMLevel;
    public int RDBMSScore;

    public int numDocs = 200;
    public int numRDBMS = 3;

    public int numShards = 1;



    public void UpdateScore(int score)
    {
        switch(score)
        {
            case > 0 and <= 5:
                playerMLevel = 0;
                break;
            case > 5 and <= 10:
                playerMLevel = 0;
                break;
            case > 10 and <= 20:
                playerMLevel = 0;
                break;
            case > 20 and <= 30:
                playerMLevel = 0;
                break;
            case > 30 and <= 39:
                playerMLevel = 0;
                break;
            case > 40 and <= 49:
                playerMLevel = 0;
                break;
            case > 50 and <= 59:
                playerMLevel = 0;
                break;
            case > 60 and <= 79:
                playerMLevel = 0;
                break;
            case > 80 and <= 99:
                playerMLevel = 0;
                break;
            case > 100 and <= 199:
                playerMLevel = 0;
                break;
            case > 200 and <= 399:
                playerMLevel = 0;
                break;
            default:
                playerMLevel = 0;
                break;
        }
 
 
    }
}
