using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetButton : MonoBehaviour
{
    public GameObject TimeCurrent;
    public GameObject TimeMax;

    public void onClick() {
        TimeCurrent.GetComponent<Text>().text = "0";
        TimeMax.GetComponent<Text>().text = "0";
        PlayerPrefs.SetString("savedTimeCurrent", "0");
        PlayerPrefs.SetString("savedTimeMax", "0");
    }
}
