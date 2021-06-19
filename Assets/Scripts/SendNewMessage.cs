using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendNewMessage : MonoBehaviour
{
    public Transform group;
    public Transform prefab;
    public InputField input;

    public void sendMessage()
    {
        var obj = Instantiate(prefab, @group, false);
        var a = obj.transform.GetComponentInChildren<Text>();
        a.text = input.text;
        input.text = "";
    }
}
