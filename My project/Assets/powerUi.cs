using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class powerUi : MonoBehaviour
{
    public static float power;
    public TextMeshProUGUI powerText;
    
    void Update()
    {
        powerText.text = power.ToString("F0");
    }
    
}
