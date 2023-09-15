using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gather : MonoBehaviour 
{
        Transform rdbms;
        public float distance;
        Rigidbody move;
    	// Use this for initialization
    	void Start () {
            move = GetComponent<Rigidbody>();
            //rdbms = GameObject.FindGameObjectWithTag("RDBMS").transform;
            rdbms = FindClosestRDBMS().transform;
            move.mass = 100*UnityEngine.Random.Range(10,100);
            //move.mass = 100;
        }
    	
    	// Update is called once per frame
    	void Update ()
        {
            // distance = Vector3.Distance(transform.position, rdbms.transform.position);
            distance = (this.transform.position - rdbms.transform.position).sqrMagnitude;
            if (distance < 115900)
            {
                //move.mass -= 10;
                move.AddForce((rdbms.transform.position - transform.position) * (1));
            }
    
        }
    
    
    
        public GameObject FindClosestRDBMS()
        {
            GameObject[] RDBMSs;
            RDBMSs = GameObject.FindGameObjectsWithTag("RDBMS");
            GameObject closestRDBMS = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject rdbms in RDBMSs)
            {
                Vector3 diff = rdbms.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closestRDBMS = rdbms;
                    distance = curDistance;
                }
            }
            return closestRDBMS;
        }
    
    
    
    }
