using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TigerForge; //easyEvent Manager
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JetBrains.Annotations;
using System.Security.Cryptography;


public class Packet
{
    public string playerName;
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
public PlayerProfile playerProfile;    

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("TELEMETRY", ProcessTelemetry);
        playerProfile = FindObjectOfType<PlayerProfile>();
    }

    void ProcessTelemetry()
    {
        var eventData = EventManager.GetDataGroup("TELEMETRY");        

        Packet packet = new Packet();

        packet.playerName = playerProfile.pp.Name;
        packet.Type = eventData[0].ToString();
        packet.Name = eventData[1].ToString();
        packet.Score = eventData[2].ToInt();
        packet.numShards = eventData[3].ToInt();
        packet.Time = eventData[4].ToString();
        packet.position_x = eventData[5].ToString();        
        packet.position_y = eventData[6].ToString();        
        packet.position_z = eventData[7].ToString();        

        Debug.Log(JsonConvert.SerializeObject(packet));

        StartCoroutine(Upload(packet));
    }

    IEnumerator Upload(Packet packet)
    {
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:4567/v1/telemetry/", JsonConvert.SerializeObject(packet), "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

