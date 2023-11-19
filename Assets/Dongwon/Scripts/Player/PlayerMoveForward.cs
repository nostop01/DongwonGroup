using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float MoveSpeed = 5f; //�����̴� �ӵ�
    public float CollideMoveSpeed; //�浹 �� �����̴� �ӵ�
    public float ableToMoveTimer = 0f; //���� �ӵ��� ���ư��� Ÿ�̸�
    public float ableToMoveTime = 2f; //Ÿ�̸� ����

    private float Timer;
    private float Times = 2;

    public Rigidbody _rigid;

    GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        ableToMoveTimer = ableToMoveTime; //���� Ÿ�̸� ����
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
        Vector3 getVel = new Vector3(MoveSpeed, 0.0f, 0.0f); //X���Ϳ� MoveSpeed�� ��ŭ ��ġ ����

        _rigid.velocity = getVel;  //������ ���͸� ������ٵ� ���ν�Ƽ ���Ϳ� ����

    }

    void CollideMove()
    {
        Vector3 getVel = new Vector3(CollideMoveSpeed, 0f, 0f); //�浹 ������Ʈ�� �´� �ӵ��� X���Ϳ� ��ġ ����

        _rigid.velocity = getVel; //������ ���͸� ������ٵ� ���ν�Ƽ ���Ϳ� ����

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