using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public static int coinAmount;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
