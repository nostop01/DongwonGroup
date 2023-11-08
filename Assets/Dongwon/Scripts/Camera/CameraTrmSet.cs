using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrmSet : MonoBehaviour
{
    public Transform PlayerTrm;

    private Vector3 CameraTrm;

    // Start is called before the first frame update
    void Start()
    {
        CameraTrm = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerTrm.position.x - 10, CameraTrm.y, CameraTrm.z);
    }
}
