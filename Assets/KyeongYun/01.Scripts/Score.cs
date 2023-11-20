using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text text;
    public static int coinAmount;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (text.text == null)
        {
            text.text = "0";
        }
        else
        {
            text.text = coinAmount.ToString();
        }
    }
}
