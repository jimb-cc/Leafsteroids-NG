using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge; //easyEvent Manager
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Packet
{
    public string Type;
    public string Name;
    public int Score;
    public int numShards;
    public string Time; 
    public string position_x;
    public string position_y;
    public string position_z;       
}


public class telemetry : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("TELEMETRY", ProcessTelemetry);
    }

    void ProcessTelemetry()
    {
        var eventData = EventManager.GetDataGroup("TELEMETRY");        

        Packet packet = new Packet();

        packet.Type = eventData[0].ToString();
        packet.Name = eventData[1].ToString();
        packet.Score = eventData[2].ToInt();
        packet.numShards = eventData[3].ToInt();
        packet.Time = eventData[4].ToString();
        packet.position_x = eventData[5].ToString();        
        packet.position_y = eventData[6].ToString();        
        packet.position_z = eventData[7].ToString();        

        Debug.Log(JsonConvert.SerializeObject(packet));
    }
}

