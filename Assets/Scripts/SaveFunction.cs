using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFunction : MonoBehaviour
{
    public InputField title, text;
    public void MySaveFunction() 
    {
        SSaving.ReadingData();
        ProfileSetting.userData.Add(title.text, text.text);
        SSaving.SavingData();
    }
}
