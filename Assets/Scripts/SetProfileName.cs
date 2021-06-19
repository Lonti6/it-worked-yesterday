using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetProfileName : MonoBehaviour
{
    
    void Start()
    {
        var text = GetComponent<Text>();
        if (ProfileSetting.PROFILE.FirstName.Length > 0)
            text.text = ProfileSetting.PROFILE.FirstName;
    }


}
