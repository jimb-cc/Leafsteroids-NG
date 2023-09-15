using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocGen : MonoBehaviour
{
    public GameObject doc;
    public GameObject rdbms;
    public int min,max;
    public Scores scores;

    // Start is called before the first frame update
    void Start()
    {
        PlaceDocs();
        PlaceRDBMS();
    }


    void PlaceDocs()
    {
        for (int i=0; i<scores.numDocs; i++)
        {
           doc = Instantiate(doc,GeneratedDocPostion(),Quaternion.identity);
           doc.name = "doc_"+i.ToString();
        }
        Debug.Log("Placed Docs");
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

    Vector3 GeneratedDocPostion()
    {
        float x,y,z;
        x = UnityEngine.Random.Range(min,max);
        y = 1;
        z = UnityEngine.Random.Range(min,max);     
        return new Vector3(x,y,z);
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
