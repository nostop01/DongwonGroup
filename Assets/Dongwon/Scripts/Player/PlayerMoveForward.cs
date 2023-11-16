using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float MoveSpeed = 5f; //움직이는 속도
    public float CollideMoveSpeed; //충돌 시 움직이는 속도
    public float ableToMoveTimer = 0f; //원래 속도로 돌아가는 타이머
    public float ableToMoveTime = 2f; //타이머 기준

    private float Timer;
    private float Times = 2;

    public Rigidbody _rigid;

    GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        ableToMoveTimer = ableToMoveTime; //시작 타이머 설정
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatus.Instance.CanMove && !PlayerStatus.Instance.Pause)
        {
            MoveFunction();
        }

        if(!PlayerStatus.Instance.CanMove && !PlayerStatus.Instance.Pause)
        {
            CollideMove();
            GoTimer();
        }

        if(PlayerStatus.Instance.Death)
        {
            _rigid.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("StoneObstacle"))
        {
            PlayerStatus.Instance.CollideObstacle = true;
            PlayerStatus.Instance.CanMove = false;

            CollideMoveSpeed = ObstacleSystem.Instance.StoneHitMoveSpeed;

            _rigid.velocity = Vector3.zero;
        }

        if(other.gameObject.name == ("SharkObstacle"))
        {
            OnDeath();
        }

        if(other.gameObject.name == ("SeaweedObstacle"))
        {
            PlayerStatus.Instance.CollideObstacle = true;
            PlayerStatus.Instance.CanMove = false;

            CollideMoveSpeed = ObstacleSystem.Instance.SeaweedHitMoveSpeed;

            _rigid.velocity = Vector3.zero;
        }

        if(other.gameObject.name == ("EndLine"))
        {
            StartCoroutine(WaitTimer(0.5f));

            PlayerStatus.Instance.Pause = true;
            PlayerStatus.Instance.Clear = true;

            Destroy(gameObject);
        }
    }

    void MoveFunction()
    {
        Vector3 getVel = new Vector3(MoveSpeed, 0.0f, 0.0f); //X벡터에 MoveSpeed값 만큼 수치 적용

        _rigid.velocity = getVel;  //설정한 벡터를 리지드바디 벨로시티 벡터에 적용

    }

    void CollideMove()
    {
        Vector3 getVel = new Vector3(CollideMoveSpeed, 0f, 0f); //충돌 오브젝트에 맞는 속도로 X벡터에 수치 적용

        _rigid.velocity = getVel; //설정한 벡터를 리지드바디 벨로시티 벡터에 적용

        if (ableToMoveTimer <= 0)
        {
            PlayerStatus.Instance.CollideObstacle = false;
            PlayerStatus.Instance.CanMove = true;
        }
    }

    public void OnDeath()
    {
        PlayerStatus.Instance.OnDeath();
        PlayerStatus.Instance.OnCannotMove();
    }

    void GoTimer()
    {
        ableToMoveTimer -= Time.deltaTime;
    }

    IEnumerator WaitTimer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
