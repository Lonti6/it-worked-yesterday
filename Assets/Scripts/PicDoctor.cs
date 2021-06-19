using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PicDoctor : MonoBehaviour
{
    public Text text;
    public Text me;
    public GameObject parent;
    private bool isDown = false;
    
    public void clicked()
    {
        Debug.Log("doctor click!");
        text.text = me.text;
        parent.SetActive(false);
            
            
    }

  
}
