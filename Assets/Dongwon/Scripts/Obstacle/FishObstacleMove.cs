using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishObstacleMove : MonoBehaviour
{
    public float Times = 9;
    public float Timer;

    public float MoveSpeed = 7f;

    Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Times;
        _rigid = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Times -= Time.deltaTime;

        if(Times <= 0)
        {
            Vector3 getVel = new Vector3(-MoveSpeed, 0, 0);
            _rigid.velocity = getVel;
        }
    }
}
