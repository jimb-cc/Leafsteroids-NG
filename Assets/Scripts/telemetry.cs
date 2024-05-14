using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge; //easyEvent Manager

public class telemetry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("TELEMETRY", ProcessTelemetry);
    }

    void ProcessTelemetry()
    {
     Debug.Log("We Got One!");
    }


}
