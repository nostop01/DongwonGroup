using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    public float StoneHitMoveSpeed = 4.5f; //돌 장애물에 충돌했을 때 속도
    public float SharkHitMoveSpeed = 4.25f; //상어 장애물에 충돌했을 때 속도
    public float SeaweedHitMoveSpeed = 3.75f; //해초 장애물에 충돌했을 때 속도

    public float SharkObstacleMoveSpeed = 2.5f; //상어 장애물이 이동하는 속도

    public bool SharkObstacle = false; //상어 장애물인지 아닌지 확인하는 boolean 변수

    Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(SharkObstacle) //만약 상어 장애물일 경우
        {
            Vector3 getVel = new Vector3(-SharkObstacleMoveSpeed, 0, 0); //플레이어가 움직이는 방향의 반대 방향으로 벡터값 설정
            _rigid.velocity = getVel; //리지드바디의 벨로시티 벡터에 설정한 벡터값 적용
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") //만약 플레이어란 이름을 가진 오브젝트에 충돌 시
        {
            Destroy(gameObject); //이 장애물 오브젝트를 삭제
        }
    }
}
