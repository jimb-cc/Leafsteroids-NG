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
                docScript.Sparkle();
                scores.UpdateScore(scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();

            }

            if(this.tag=="RDBMS")
            {
                docScript.BadSparkle();
                scores.RDBMSScore ++;
                scores.UpdateScore(scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();
            }
        }

        else if (other.CompareTag("shardPU"))
        {
            scores.numShards ++;
            docScript.PUSparkle();
            scores.UpdateScore(scores.playerScore, scores.numShards);
            uiman.UpdateScoreUI();

        }
    }


 }