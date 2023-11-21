using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMP_Text text;
    public static int coinAmount = 0;

    Data data = new Data();

    void Start()
    {
        
    }

    void Update()
    {
        text.text = coinAmount.ToString();
    }

    private void OnDisable()
    {
        DataManager.Instance.SaveCoinData(coinAmount);
    }

    private void OnEnable()
    {
        DataManager.Instance.LoadGameData();
    }
}
