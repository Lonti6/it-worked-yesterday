using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class GetHttp : MonoBehaviour
    {
        void Start()
        {
            
           
        }

        IEnumerator GetRequest(string uri, string postData)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, postData))
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
                        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                        break;
                }
            }
        }
    }
}