using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSetting 
{
    public string FirstName = "";
    public string LastName = "";
    public string Phone = "";
    public string Password = "";
    public static ProfileSetting PROFILE = new ProfileSetting();
    public static Dictionary<string, string> userData = new Dictionary<string, string> { };
    public static Dictionary<string, int> answerUsers = new Dictionary<string, int> { };

    public static void saveProfile()
    {
        var p = PROFILE;
        PlayerPrefs.SetString("name", p.FirstName);
        PlayerPrefs.SetString("phone", p.Phone);
        PlayerPrefs.Save();
    }

    public static void loadProfile()
    {
        if (PlayerPrefs.HasKey("name"))
            PROFILE.FirstName = PlayerPrefs.GetString("name");
        if (PlayerPrefs.HasKey("phone"))
            PROFILE.Phone = PlayerPrefs.GetString("phone");
    }
    
    
}
