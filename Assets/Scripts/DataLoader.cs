using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class DataLoader : MonoBehaviour
{
    private string url = "https://api.staging.leafsteroids.net/Events";

    public class Event
    {
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }

    void Start()
    {
        StartCoroutine(GetRequest(url)); 
    }


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    JArray events_a = JArray.Parse( webRequest.downloadHandler.text);
                    Debug.Log(events_a);    

                    List<Event> events = events_a.ToObject<List<Event>>();

                    Debug.Log(events[0].name);
                    break;
            }
        }
    }
}
