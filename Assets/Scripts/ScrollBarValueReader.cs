using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarValueReader : MonoBehaviour
{
    public Scrollbar sb;
    public Text text;
    public void Changs() 
    {
        text.text = (Mathf.Round(sb.value * 60)).ToString()+" градусов";
    }

}
