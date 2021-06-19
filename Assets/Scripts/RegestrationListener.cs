using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;


public class RegestrationListener : MonoBehaviour
{
    public InputField name;
    public InputField phone;
    public InputField password;

    public GetHttp http;

    private void Start()
    {
        Debug.Log("http stated...");
    }

    public void OnClickRegestration()
    {
        ProfileSetting.PROFILE.FirstName = name.text;
        ProfileSetting.PROFILE.Phone = phone.text;
        ProfileSetting.PROFILE.Password = password.text;
        Debug.Log("set regestration");

        var p = ProfileSetting.PROFILE;
        http.sendRegistration(new Registration(p.Phone, p.Password, p.FirstName));
    }
}
