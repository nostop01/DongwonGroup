using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressGauge : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    public GameObject startPos; // ���� ��ġ
    public GameObject endPos;   // �������� ��ġ
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