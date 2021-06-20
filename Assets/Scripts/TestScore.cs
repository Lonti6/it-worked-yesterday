using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScore : MonoBehaviour
{
    public int Score;
    public string NameQuest;
    public Scrollbar sb;
    public Text finalyPecent;
    public void corDic() 
    {
        ProfileSetting.answerUsers.Add(NameQuest, Score);
    }
    public void corDicSb()
    {
        if (sb.value*60 >37.5) ProfileSetting.answerUsers.Add(NameQuest, 1);
        else ProfileSetting.answerUsers.Add(NameQuest, 1);
    }
    public void corDicSbOther()
    {
        ProfileSetting.answerUsers.Add(NameQuest, sb.value);
    }
    public void finalyScore()
    {
        float w = 0;
        foreach(var i in ProfileSetting.answerUsers.Values) 
        {
            w += i;
        }
        finalyPecent.text = (w * 100 / 14).ToString()+"%";
    }
}
