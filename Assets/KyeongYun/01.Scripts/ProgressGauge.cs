using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressGauge : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    public GameObject startPos; // 시작 위치
    public GameObject endPos;   // 종료지점 위치
    public GameObject followObject;
    private float length;
    private float pPos;

    void Update()
    {
        Progress();
    }
    void Progress()
    {
        pPos = followObject.transform.position.x - startPos.transform.position.x;
        length = endPos.transform.position.x - startPos.transform.position.x;
        progressBar.value = pPos / length;
    }
}
