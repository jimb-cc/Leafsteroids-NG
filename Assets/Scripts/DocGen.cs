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
        PlaceDocs();
        PlaceRDBMS();
          
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
        for (int i=0; i<scores.numRDBMS; i++)
        {
            rdbms = Instantiate(rdbms,GeneratedRDBMSPostion(),Quaternion.identity);
            rdbms.name = "rdbms_"+i.ToString();
        }
        Debug.Log("Placed RDBMS");
    }

    Vector3 GeneratedDocPostion(float yPos)
    {
        float x,z;
        x = UnityEngine.Random.Range(min,max);
        z = UnityEngine.Random.Range(min,max);     
        return new Vector3(x,yPos,z);
    }

    Vector3 GeneratedRDBMSPostion()
    {
        float x,y,z;
        x = UnityEngine.Random.Range(min,max);
        y = 0.01f;
        z = UnityEngine.Random.Range(min,max);     
        return new Vector3(x,y,z);
    }

}
