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

    private GameObject playerObj = null;

    UIManager uiman;
    Scores scores;

    void Start()
    {
        scores = FindObjectOfType<Scores>(); 
        uiman = FindObjectOfType<UIManager>(); 
        if (playerObj == null) playerObj = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnTriggerEnter(Collider other)
    {
        
        var docScript = other.GetComponent<DocRot>();
        
        if (other.CompareTag("document"))
        {
            if(this.tag=="Player" && !docScript.beingCollected)
            {
                Scores.playerScore ++;
                docScript.Sparkle();
                scores.UpdateScore(Scores.playerScore, scores.numShards);
                uiman.UpdateScoreUI();
                // send telemetry packet
                EventManager.SetDataGroup(
                    "TELEMETRY", 
                    "document", 
                    other.gameObject.name, 
                    Scores.playerScore, 
                    scores.numShards, 
                    System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    playerObj.transform.position.x.ToString(),
                    playerObj.transform.position.y.ToString(),
                    playerObj.transform.position.z.ToString() 
                );
                
                
                
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
            // send telemetry packet
            EventManager.SetDataGroup(
                    "TELEMETRY", 
                    "shardPU", 
                    other.gameObject.name, 
                    Scores.playerScore, 
                    scores.numShards, 
                    System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    playerObj.transform.position.x.ToString(),
                    playerObj.transform.position.y.ToString(),
                    playerObj.transform.position.z.ToString() 
            );

            
            
            
            EventManager.EmitEvent("TELEMETRY");

        }
    }


 }