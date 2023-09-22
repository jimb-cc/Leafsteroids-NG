using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float docTankHeight = 0.01f;

    UIManager uiman;
    Scores scores;

    void Start()
    {
        scores = FindObjectOfType<Scores>(); 
        uiman = FindObjectOfType<UIManager>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Name of the object: " + other.gameObject.name + " it's tag is " + other.gameObject.tag + "and this things tag is: " + this.tag);

        if (other.CompareTag("document"))
        {
            if(this.tag=="Player")
            {
                scores.playerScore ++;
                docTankHeight += (float)scores.playerScore/500;
                var docTank = GameObject.Find("Shard1");
                //var carCoM = GameObject.Find("CoM");
                docTank.gameObject.transform.localScale = new Vector3(docTankHeight,docTankHeight,docTankHeight);
                //docTank.gameObject.transform.localPosition = new Vector3(0,(docTankHeight/2),0);
                //carCoM.gameObject.transform.localPosition = new Vector3(0,(docTankHeight*2),0);
                var docScript = other.GetComponent<DocRot>();
                docScript.Sparkle();
                //Debug.Log("Score = "+scores.playerScore.ToString());
                //Debug.Log("carBodyHeight = "+docTankHeight.ToString());
                uiman.UpdateScore(scores.playerScore);
            }

            if(this.tag=="RDBMS")
            {
                var docScript = other.GetComponent<DocRot>();
                docScript.BadSparkle();
                //Debug.Log("destroyed by RDBMS - current RDBMS Score is " +scores.RDBMSScore);
                scores.RDBMSScore ++;
                uiman.UpdateRDBMSScore();
            }
        }
        else if (other.CompareTag("shardPU"))
        {
            Debug.Log("ShardPU hit by " + this.tag);
            //Destroy(other);
        }
    }
 }