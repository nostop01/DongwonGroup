using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool CanMove = true; //게임오버가 아닐 때, 게임이 끝나지 않았을 때 움직이도록 하는 변수

    Rigidbody _rigid;
    Vector3 getVel;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove) //움직일 수 있는 상태일때
        {
            getVel = new Vector3(MoveSpeed, 0.0f, 0.0f);

            _rigid.velocity = getVel;  //무조건 앞으로 나아감
        }
    }
}
