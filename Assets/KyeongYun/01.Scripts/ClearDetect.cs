using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearDetect : MonoBehaviour
{
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==("Wall"))
        {
            Debug.Log("클리어");
            StageClear();
        }
    }
    void StageClear()
    {
        Debug.Log("애니메이션 출력 후 다음 스테이지로");
    }
}
