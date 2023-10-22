using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public DocGen docGen;
    public ConfigLoader cl;
    public int playerScore;
    public string playerMLevel;
    public int RDBMSScore;
    public int left;

    public int numDocs = 0;
    public int numRDBMS = 0;

    public int numShards = 1;
    public int docsInTank = 0;
    public float repsetSize = 1;
    public int scaleFactor = 10;

    public void UpdateScore(int score, int numShards)
    {
        Debug.Log("Is data loaded? "+cl.dataLoaded);        
        if (cl.dataLoaded) 
        {
            left = (int)cl.configdata["numDocs"]["$numberInt"] - (playerScore+RDBMSScore);
        } 
        else
        {
            left = 0;
        }
        var shards = GameObject.Find("Shards");
        docsInTank = score/numShards;
        
        switch(docsInTank)
        {
            case > 0 and <= 5:
                playerMLevel = "Free Tier";
                repsetSize = 5;
                break;
            case > 5 and <= 10:
                playerMLevel = "M2";
                repsetSize = 10;
                break;
            case > 10 and <= 20:
                playerMLevel = "M5";
                repsetSize = 15;
                break;
            case > 20 and <= 30:
                playerMLevel = "M10";
                repsetSize = 20;
                break;
            case > 30 and <= 40:
                playerMLevel = "M20";
                repsetSize = 25;
                break;
            case > 40 and <= 50:
                playerMLevel = "M30";
                repsetSize = 30;
                break;
            case > 50 and <= 60:
                playerMLevel = "M40";
                repsetSize = 40;
                if (docGen.numShardPUsDropped<1) docGen.PlaceShardPickup();
                break;
            case > 60 and <= 80:
                playerMLevel = "M60";
                repsetSize = 60;
                if (docGen.numShardPUsDropped<2) docGen.PlaceShardPickup();
                break;
            case > 80 and <= 100:
                playerMLevel = "M80";
                repsetSize = 80;
                if (docGen.numShardPUsDropped<3) docGen.PlaceShardPickup();
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
        scaleShards();

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

            case 4:
            shards.transform.GetChild(3).gameObject.SetActive(true); 
            break; 

        }
    }
    public void scaleShards()
    {
        var shards = GameObject.Find("Shards");
        /*
        I have to scale the individual prefabs, rather than the parent that they are all connected to, 
        so that the distance between the children doesn't scale out too.
        */
        //shards.gameObject.transform.localScale = new Vector3(repsetSize,repsetSize,repsetSize);


        // I should detect how many children there are and then loop through 
        float scaledRepSetSize = repsetSize / scaleFactor;
        shards.transform.GetChild(0).gameObject.transform.localScale = new Vector3(scaledRepSetSize,scaledRepSetSize,scaledRepSetSize);
        shards.transform.GetChild(1).gameObject.transform.localScale = new Vector3(scaledRepSetSize,scaledRepSetSize,scaledRepSetSize);
        shards.transform.GetChild(2).gameObject.transform.localScale = new Vector3(scaledRepSetSize,scaledRepSetSize,scaledRepSetSize);
        shards.transform.GetChild(3).gameObject.transform.localScale = new Vector3(scaledRepSetSize,scaledRepSetSize,scaledRepSetSize);
    }
}
