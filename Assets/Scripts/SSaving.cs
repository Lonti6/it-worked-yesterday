using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SSaving
{
    public static void SavingData()
    {
        FileStream file = File.Create(Application.persistentDataPath
          + "/SSaveData.txt");
        StreamWriter f = new StreamWriter(Application.persistentDataPath
          + "/SSaveData.txt", true);
        foreach(var i in ProfileSetting.userData.Keys) 
        {
            f.WriteLine(i + "`" + ProfileSetting.userData[i]);
        }
        file.Close();
        f.Close();
        Debug.Log("Game data saved!");
    }
    public static void ReadingData() 
    {
        try
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath
          + "/SSaveData.txt");
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] words = line.Split(new char[] { '`' });
                if (ProfileSetting.userData.ContainsKey(words[0])) ProfileSetting.userData[words[0]] = words[1];
                else ProfileSetting.userData.Add(words[0], words[1]);
            }
            sr.Close();
        }
        catch 
        {
            Debug.Log(ProfileSetting.userData.Count);
        }
        
    }

}
