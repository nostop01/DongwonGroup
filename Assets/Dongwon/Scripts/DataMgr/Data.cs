using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Data //���ϴ� ������/������ ����/���� ������ ����.
{
    public bool[] isUnlock = new bool[8]; //�������� Ŭ���� ����

    public float[] SettingState = new float[3]; //������ ����

    public float[] CointCount = new float[1]; //���� ���� ����
}