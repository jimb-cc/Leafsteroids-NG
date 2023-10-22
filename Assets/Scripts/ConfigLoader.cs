
/*

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ConfigLoader : MonoBehaviour
{
    public JObject configdata;
    public Scores scores;
    public bool dataLoaded = false;
    void Start()
    {
        StartCoroutine(GetRequest("https://us-east-1.aws.data.mongodb-api.com/app/gds-qmybd/endpoint/getconfig?secret=ssshhh"));
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
                    Debug.Log(webRequest.downloadHandler.text);

                    configdata = JObject.Parse(webRequest.downloadHandler.text);
                    //JObject configdata = JObject.Parse(webRequest.downloadHandler.text);
                    //JArray eventdata = JArray.Parse(webRequest.downloadHandler.text);
                
                    dataLoaded=true;

                    break;
            }
        }
    }


}

// https://us-east-1.aws.data.mongodb-api.com/app/gds-qmybd/endpoint/getconfig?secret=ssshhh


*/