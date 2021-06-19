using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerText : MonoBehaviour
{
    public static void ChangeText(Text text)
    {
        foreach(var i in ProfileSetting.userData.Keys) 
        {
            text.text += i + "\n" + "*" + ProfileSetting.userData[i] + "\n";
        }
    }
}
