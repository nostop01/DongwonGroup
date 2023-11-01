using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearDetect : MonoBehaviour
{
    float speed;
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==("Wall"))
        {
            Debug.Log("Å¬¸®¾î");
        }
        StageClear();
    }
    void StageClear()
    {

    }
}
