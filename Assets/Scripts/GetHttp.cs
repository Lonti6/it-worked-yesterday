using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class GetHttp : MonoBehaviour
    {
        private string uri = "localhost:8080/";
        void Start()
        {
            
           
        }

        public void sendRegistration(Registration reg)
        {
            var postData = JsonUtility.ToJson(reg);
            Debug.Log(postData);
            StartCoroutine(GetRequest(uri + "registration", postData));
        }

        public void sendNewNote(Note note)
        {
            var postData = JsonUtility.ToJson(note);
            Debug.Log(postData);
            StartCoroutine(GetRequest(uri + "create-note", postData));
        }

        IEnumerator GetRequest(string uri, string postData)
        {
            byte[] bytes = Encoding.Default.GetBytes(postData);
            using (UnityWebRequest request = new UnityWebRequest(uri, "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(bytes) {contentType = "application/json"};
                request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
                request.SetRequestHeader("Accept", "application/json");
                // Request and wait for the desired page.
                yield return request.SendWebRequest();
                Debug.Log("send success!");

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                switch (request.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + request.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + request.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log(pages[page] + ":\nReceived: " + request.downloadHandler.text);
                        break;
                }
            }
        }
    }
}