using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocGen : MonoBehaviour
{
    public GameObject doc;
    public GameObject rdbms;
    public GameObject shardPU;
    public int min,max;
    public Scores scores;

    public int numShardPUsDropped = 0;

    // Start is called before the first frame update
    void Start()
    {
            PlaceRDBMS();
            PlaceDocs();

    }


    public void PlaceShardPickup()
    {
           shardPU = Instantiate(shardPU,GeneratedDocPostion(2f),Quaternion.identity); // using doc position becuase it's good enough
           numShardPUsDropped ++;
    }


    void PlaceDocs()
    {
       
        for (int i=0; i<scores.numDocs; i++)
        {
           doc = Instantiate(doc,GeneratedDocPostion(1f),Quaternion.identity);
           doc.name = "doc_"+i.ToString();
        }
        
    }


    void PlaceRDBMS()
    {
        
        //for (int i=0; i<scores.numRDBMS; i++)
        for (int i=0; i<scores.numRDBMS; i++)
        {
            rdbms = Instantiate(rdbms,GeneratedRDBMSPostion(i),Quaternion.identity);
            rdbms.name = "rdbms_"+i.ToString();
        }
    }

    Vector3 GeneratedDocPostion(float yPos)
    {
        float x,z;
        x = UnityEngine.Random.Range(min,max);
        z = UnityEngine.Random.Range(min,max);     
        return new Vector3(x,yPos,z);
    }

    Vector3 GeneratedRDBMSPostion(int i)
    {
        float x,y,z;
        Debug.Log("doing RDBMS: " +i);
        switch(i)
        {
            case 0:
                x = max/2f;
                y = 0.01f;
                z = 0.0f;
            break;

            case 1:
                x = min/2f;
                y = 0.01f;
                z = 0.0f;
            break;

            case 2:
                x = 0.0f
                y = 0.01f;
                z = max/2f;
            break;

            case 3:
                x = 0.0f
                y = 0.01f;
                z = min/2f;
            break;


            default:
                x = UnityEngine.Random.Range(min,max);
                y = 0.01f;
                z = UnityEngine.Random.Range(min,max);     
            break;
        }
        return new Vector3(x,y,z);
        
    }

}
