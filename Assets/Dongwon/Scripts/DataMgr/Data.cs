using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Data //원하는 데이터/데이터 형식/갯수 등으로 저장.
{
    public bool[] isUnlock = new bool[8]; //스테이지 클리어 상태

    public float[] SettingState = new float[3]; //설정값 저장

    public int[] CointCount = new int[1]; //코인 갯수 저장
}
