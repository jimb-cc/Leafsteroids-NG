using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TigerForge; //Easy Event Manager

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
            if(this.tag=="Player" && !docScript.beingCollected)
            {
                Scores.playerScore ++;
                docScript.Sparkle();
                scores.UpdateScore(Scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();
                EventManager.SetDataGroup("TELEMETRY", "document", other.gameObject.name, scores.playerScore, System.DateTime.UtcNow.ToString() );
                EventManager.EmitEvent("TELEMETRY");
            }

            if(this.tag=="RDBMS" && !docScript.beingCollected)
            {
                docScript.BadSparkle();
                Scores.RDBMSScore ++;
                scores.UpdateScore(Scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();
            }
        }

        else if (other.CompareTag("shardPU"))
        {
            scores.numShards ++;
            docScript.PUSparkle();
            scores.UpdateScore(Scores.playerScore, scores.numShards);
            uiman.UpdateScoreUI();

        }
    }


 }