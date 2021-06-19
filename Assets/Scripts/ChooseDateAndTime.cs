using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChooseDateAndTime : MonoBehaviour
{
    public ScrollRect days;
    public ScrollRect mounts;
    public ScrollRect year;
    public ScrollRect hour;
    public ScrollRect minut;

    private GetHttp _http;
    public Text textMessage;
    public Text doctor;

    private void Start()
    {
        _http = GetComponent<GetHttp>();
    }

    public void pressButton()
    {
        var curr_day = Mathf.RoundToInt((1 - days.normalizedPosition.y) * 30f) + 1;
        var curr_mount = Mathf.RoundToInt((1 - mounts.normalizedPosition.y) * 11f) + 1;
        var curr_year = Mathf.RoundToInt((1 - year.normalizedPosition.y) * 4f) + 2020;
        var curr_hour = Mathf.RoundToInt((1 - hour.normalizedPosition.y) * 23f) ;
        var curr_minut = Mathf.RoundToInt((1 - minut.normalizedPosition.y) * 59f) ;
        
        Debug.Log(""+ curr_day + "." + curr_mount + "." + curr_year +  " " + curr_hour + ":" + curr_minut);

        var date = new DateTime(curr_year, curr_mount, curr_day, curr_hour, curr_minut, 0);
        Debug.Log("date=" + date);
        Debug.Log("toJson=" + JsonUtility.ToJson(date));
        var p = ProfileSetting.PROFILE;
        var note = new Note(p.Phone, textMessage.text, date.GetDateTimeFormats('s')[0], doctor.text);
        _http.sendNewNote(note);
    }
}
