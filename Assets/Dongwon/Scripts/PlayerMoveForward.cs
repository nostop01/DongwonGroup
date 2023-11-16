using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float MoveSpeed = 5f; //움직이는 속도
    public float CollideMoveSpeed = 4.5f; //충돌 시 움직이는 속도
    public float ableToMoveTimer = 0f; //원래 속도로 돌아가는 타이머
    public float ableToMoveTime = 2f; //타이머 기준

    private float Timer;
    private float Times = 2;

    public bool CanMove = true; //게임오버가 아닐 때, 게임이 끝나지 않았을 때 움직이도록 하는 변수
    public bool CollideObstacle = false; //오브젝트에 부딫혔는지 아닌지 확인하는 boolean변수
    public bool Death = false; //플레이어 상태 확인하는 변수
    public bool Pause = false; //게임오버, 게임이 끝났거나, 게임이 일시중지 되었을 때, 시작하기 전에 사용하는 변수

    public Rigidbody _rigid;

    ObstacleSystem _obstacleSystem; //장애물 별 감소하는 속도 받아오기
    GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
        _obstacleSystem = FindObjectOfType<ObstacleSystem>(); //ObstacleSystem 보유한 오브젝트 찾기

        ableToMoveTimer = ableToMoveTime; //시작 타이머 설정
    }

    // Update is called once per frame
    void Update()
    {
        if(!Death) //플레이어가 죽음상태가 아닐 때
        {
            if(!Pause) //만약 퍼즈상태가 아니면
            {
                MoveFunction();  //기본적으로 이동하는 함수
                CollideMove(); //충돌 시 이동하는 함수
                ResetMoveVector(); //움직임 벡터 초기화하는 함수
            }
        }

        else if(Death)
        {
            Timer = Times;
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                Debug.Log("플레이어 죽음");
                //_gameManager.gameState == gameOver;
                _gameManager.GameOver();
                
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "StoneObstacle") //돌 장애물에 부딫혔을때
        {
            CollideObstacle = true; //장애물 충돌 감지 boolean형 변수 true 변경
            CanMove = false; //움직이게 하는 boolean형 변수 false 변경

            CollideMoveSpeed = _obstacleSystem.StoneHitMoveSpeed; //장애물 시스템의 돌에 부딫혔을 때 속도로 충돌 시 속도 변경

            _rigid.velocity = Vector3.zero; //속도를 바로 적용시키기 위해서 플레이어 리지드바디 벨로시티의 벡터값을 0,0,0으로 변경 후 

            ableToMoveTime = 2f; //이동속도 감소 시간만큼 타이머 기준값 변경

            ableToMoveTimer = ableToMoveTime; //타이머에 타이머 기준값 적용
        }

        if (other.gameObject.name == "SharkObstacle") //상어 장애물에 부딫혔을때
        {   /*
            //이후 동일
            CollideObstacle = true;
            CanMove = false;

            CollideMoveSpeed = _obstacleSystem.SharkHitMoveSpeed;

            _rigid.velocity = Vector3.zero;

            ableToMoveTime = 3f;

            ableToMoveTimer = ableToMoveTime;
            */

            OnDeath(); //상어 오브젝트는 즉사이기 때문에 OnDeath 함수 호출
        }

        if(other.gameObject.name == "SeaweedObstacle") //해초 장애물에 부딫혔을 때
        {
            //이후 동일
            CollideObstacle = true;
            CanMove = false;

            CollideMoveSpeed = _obstacleSystem.SeaweedHitMoveSpeed;

            _rigid.velocity = Vector3.zero;

            ableToMoveTime = 1.5f;

            ableToMoveTimer = ableToMoveTime;
        }
    }

    void MoveFunction()
    {
        if (CanMove) //움직일 수 있는 상태일때
        {
            Vector3 getVel = new Vector3(MoveSpeed, 0.0f, 0.0f); //X벡터에 MoveSpeed값 만큼 수치 적용 

            _rigid.velocity = getVel;  //설정한 벡터를 리지드바디 벨로시티 벡터에 적용
        }
        else
        {
            _rigid.velocity = Vector3.zero;
        }
        
    }

    void CollideMove()
    {
        if (CollideObstacle) //오브젝트에 부딫혀 boolean 함수가 true 시
        {
            ableToMoveTimer -= Time.deltaTime; //타이머 시작

            Vector3 getVel = new Vector3(CollideMoveSpeed, 0f, 0f); //충돌 오브젝트에 맞는 속도로 X벡터에 수치 적용

            _rigid.velocity = getVel; //설정한 벡터를 리지드바디 벨로시티 벡터에 적용
        }
    }

    void ResetMoveVector()
    {
        if (ableToMoveTimer <= 0f) //타이머가 0이 되면
        {
            CollideObstacle = false; //장애물 충돌 boolean 변수 끄기 

            CanMove = true; //다시 움직일 수 있게 변경

            _rigid.velocity = Vector3.zero; //속도를 바로 적용시키기 위해서 플레이어 리지드바디 벨로시티의 벡터값을 0,0,0으로 변경 후 

            ableToMoveTimer = ableToMoveTime; //타이머 초기화
        }
    }

    public void OnDeath()
    {
        Death = true;
        CanMove = false;
    }
}
