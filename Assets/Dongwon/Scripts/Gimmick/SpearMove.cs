using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMove : PoolAble
{
    public float MoveSpeed = 100f; //창 속도
     
    public float destroyTimer; //오브젝트 반환을 위한 타이머
    public float destroyTime = 2; //오브젝트 반환 타이머 기준값

    Rigidbody _rigid;

    PlayerMoveForward _moveForward;

    // Start is called before the first frame update
    void OnEnable() //오브젝트 활성화 되었을 때
    {
        _rigid = GetComponent<Rigidbody>(); //리지드바디 컴포넌트 받아오고
        _moveForward = FindObjectOfType<PlayerMoveForward>(); //PlayerMoveForward 컴포넌트가 있는 오브젝트 찾기

        Vector3 getVel = new Vector3(MoveSpeed, 0, 0); //벡터3 에 X 벡터에 창 속도 주고
        _rigid.AddForce(getVel, ForceMode.Impulse); // getVel 벡터만큼 힘을 더해 던지는 효과 제공

        destroyTimer = destroyTime; //타이머 기준값 반영
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime; //타이머 감소

        if(destroyTimer <= 0) //타이머가 0 이하일 때
        {
            ReleaseObject(); //오브젝트 반환하고
            Vector3 getVel = Vector3.zero; //getVel에 벡터 0,0,0 값 부여
            _rigid.velocity = getVel; //리지드바디에 벡터값을 0,0,0으로 변경해 오브젝트 풀 이후 다시 생성되었을 때 속도가 늘어나는 경우 방지
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") //플레이어 이름을 가진 오브젝트와 부딫힐 때
        {
            _moveForward.CanMove = false; //찾아둔 스크립트 컴포넌트의 CanMove를 false로
            _moveForward._rigid.velocity = Vector3.zero; //오브젝트를 찾아둔 거기 때문에 오브젝트에 리지드바디의 벡터값을 0,0,0으로 변경(즉시 멈추게)
        }
    }
}
