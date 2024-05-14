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
    public string Time;   
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
        // EventManager.SetDataGroup("TELEMETRY", "document", other.gameObject.name, scores.playerScore, System.DateTime.UtcNow.ToString() );
        var eventData = EventManager.GetDataGroup("TELEMETRY");        
        
        //string jsonOutput = JsonConvert.SerializeObject(eventData); 
        //Debug.Log(jsonOutput);
        
        Packet packet = new Packet();
      

        packet.Type = eventData[0].ToString();
        packet.Name = eventData[1].ToString();
        packet.Score = eventData[2].ToInt();
        packet.Time = eventData[3].ToString();        

        Debug.Log(JsonConvert.SerializeObject(packet));

/*        string objectType = eventData[0].ToString();
        string objectName = eventData[1].ToString();
        int playerScore = eventData[2].ToInt();
        string eventTime = eventData[3].ToString();        
        
        Debug.Log("We Got One! " + objectType + " - " + objectName + " - "  + playerScore.ToString() + " - " + eventTime);
  */      
    }
}


/*
[{"data":"document","id":null},{"data":"doc_93","id":null},{"data":13,"id":null},{"data":"14/05/2024 20:18:53","id":null}]
[{"data":"document","id":null},{"data":"doc_53","id":null},{"data":14,"id":null},{"data":"14/05/2024 20:19:05","id":null}]
*/