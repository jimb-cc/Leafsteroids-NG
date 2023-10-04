using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
                docTankHeight += (float)scores.docsInTank/500;
                var docTank = GameObject.Find("Shard1");
                docTank.gameObject.transform.localScale = new Vector3(docTankHeight,docTankHeight,docTankHeight);
                var docScript = other.GetComponent<DocRot>();
                docScript.Sparkle();
                //uiman.UpdateScore(scores.playerScore);
                scores.UpdateScore(scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();

            }

            if(this.tag=="RDBMS")
            {
                var docScript = other.GetComponent<DocRot>();
                docScript.BadSparkle();
                //Debug.Log("destroyed by RDBMS - current RDBMS Score is " +scores.RDBMSScore);
                scores.RDBMSScore ++;
                uiman.UpdateRDBMSScoreUI();
            }
        }
        else if (other.CompareTag("shardPU"))
        {
            Debug.Log("ShardPU hit by " + this.tag);
            scores.numShards ++;
            //Destroy(other);
        }
    }
 }