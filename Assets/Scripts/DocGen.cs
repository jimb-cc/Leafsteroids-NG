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

    Vector3[] RDBMSpositions = { 
                                new Vector3 { x =  25, y = 0.01f, z =   0}, 
                                new Vector3 { x = -25, y = 0.01f, z =   0}, 
                                new Vector3 { x =   0, y = 0.01f, z =  25}, 
                                new Vector3 { x =   1, y = 0.01f, z = -25} 
                               };

    // Start is called before the first frame update
    void Start()
    {
            PlaceRDBMS();
            PlaceDocs();

    }


    public void PlaceShardPickup()
    {
           shardPU = Instantiate(shardPU,GeneratedDocPostion(2f,2f,1),Quaternion.identity); // using doc position becuase it's good enough
           numShardPUsDropped ++;
    }


    void PlaceDocs()
    {
       
        for (int i=0; i<scores.numDocs; i++)
        {
           doc = Instantiate(doc,GeneratedDocPostion(1f,10f,i),Quaternion.identity);
           doc.name = "doc_"+i.ToString();
        }
        
    }


    void PlaceRDBMS()
    {
        
        //for (int i=0; i<scores.numRDBMS; i++)
        for (int i=0; i<scores.numRDBMS; i++)
        {
            rdbms = Instantiate(rdbms,RDBMSpositions[i],Quaternion.identity);
            rdbms.name = "rdbms_"+i.ToString();
        }
    }

    Vector3 GeneratedDocPostion(float yPos, float padding, int docID)
    {
        float x,z,dis;
        bool tooCloseToRDBMS = false;
        Vector3 pos;
        int attempt =0;
        do
        { 
            x = UnityEngine.Random.Range(min,max);
            z = UnityEngine.Random.Range(min,max); 
            
            pos = new Vector3(x,yPos,z);
            tooCloseToRDBMS=false;
            for (int i = 0; i<scores.numRDBMS; i++)
            {
                dis = Vector3.Distance(pos, RDBMSpositions[i]);
                if (dis <= padding)
                {
                    attempt ++;
                    tooCloseToRDBMS = true;
                    //Debug.Log("attempt: "+attempt+" DocID: "+docID+" Go around on RDBMS "+i+": with distance "+dis+" docLoc:" +pos+ " RDBMSLoc:" +RDBMSpositions[i]);
                } 
            }
        }
        while (tooCloseToRDBMS==true);
        return pos;
    }
}
