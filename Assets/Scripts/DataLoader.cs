using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using TMPro;

public class DataLoader : MonoBehaviour
{
    private string url = "https://api.staging.leafsteroids.net/Events";

    public eventDropDown eventdropdown;

    public class Event
    {
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }

    public List<Event> events;

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

                    //List<Event> events = events_a.ToObject<List<Event>>();
                    events = events_a.ToObject<List<Event>>();

                    Debug.Log(events[0].name);
                    Debug.Log(events.Count);

                    for (int i = 0; i<events.Count; i++)
                    {
                        Debug.Log(events[i].name);
                        eventdropdown.TMPDropdown.options.Add (new TMP_Dropdown.OptionData() {text=events[i].name});
                    }                   


                    break;

                    //https://forum.unity.com/threads/load-dropdown-with-data-from-list.412860/
                    //https://docs.unity3d.com/2018.1/Documentation/ScriptReference/UI.Dropdown.AddOptions.html
                    

            }
        }
    }
}
