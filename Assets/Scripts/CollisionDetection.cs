using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionDetection : MonoBehaviour
{
    public float repsetSize = 0.01f;

    UIManager uiman;
    Scores scores;

    void Start()
    {
        scores = FindObjectOfType<Scores>(); 
        uiman = FindObjectOfType<UIManager>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Name of the object: " + other.gameObject.name + " it's tag is " + other.gameObject.tag + "and this things tag is: " + this.tag);
        
        var docScript = other.GetComponent<DocRot>();
        
        if (other.CompareTag("document"))
        {
            if(this.tag=="Player")
            {
                scores.playerScore ++;
                repsetSize = (float)scores.repsetSize/10;
                var shards = GameObject.Find("Shards");
                //shards.gameObject.transform.localScale = new Vector3(repsetSize,repsetSize,repsetSize);
                shards.transform.GetChild(0).gameObject.transform.localScale = new Vector3(repsetSize,repsetSize,repsetSize);
                shards.transform.GetChild(1).gameObject.transform.localScale = new Vector3(repsetSize,repsetSize,repsetSize);
                shards.transform.GetChild(2).gameObject.transform.localScale = new Vector3(repsetSize,repsetSize,repsetSize);
                shards.transform.GetChild(3).gameObject.transform.localScale = new Vector3(repsetSize,repsetSize,repsetSize);
                docScript.Sparkle();
                scores.UpdateScore(scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();

            }

            if(this.tag=="RDBMS")
            {
                //var docScript = other.GetComponent<DocRot>();
                docScript.BadSparkle();
                scores.RDBMSScore ++;
                uiman.UpdateRDBMSScoreUI();
            }
        }

        else if (other.CompareTag("shardPU"))
        {
            Debug.Log("ShardPU hit by " + this.tag);
            
            scores.numShards ++;
            docScript.PUSparkle();
            uiman.UpdateScoreUI();

        }
    }
 }