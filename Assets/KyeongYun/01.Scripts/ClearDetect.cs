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
        if(other.gameObject.tag==("EndLine"))
        {
            Debug.Log("Å¬¸®¾î");
            StageClear();
        }
    }
    void StageClear()
    {
        //
    }
}
