using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 45) transform.position = new Vector3(-45,transform.position.y,transform.position.z);
        else if (transform.position.x < -45) transform.position = new Vector3(45,transform.position.y,transform.position.z);

        if (transform.position.z > 45) transform.position = new Vector3(transform.position.x,transform.position.y,-45);
        else if (transform.position.z < -45) transform.position = new Vector3(transform.position.x,transform.position.y,45);
    }
}
