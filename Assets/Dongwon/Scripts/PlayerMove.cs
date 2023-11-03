using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isPosUp = false; //각 포지션마다 boolean 변수 제공
    public bool isPosDown = false;
    public bool isPosLeft = false;
    public bool isPosRight = false;

    public bool MovePosUp = false;
    public bool MovePosDown = false;
    public bool MovePosLeft = false;
    public bool MovePosRight = false;

    public float LerpSpeed = 0.025f;

    private float MoveDel = 0.35f; //움직임 쿨타임
    private float MoveDelCurrent = 0.35f; //움직임 쿨타임 적용 변수

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerPos();
        PlayerInput();
        PlayerMovement();

        MoveDelCurrent -= Time.deltaTime; //적용된 변수 값 0으로 만들고
    }

    void CheckPlayerPos()
    {
        //플레이어 위치 실시간 체크
        if(transform.position.y <= 1.6) //아래쪽 위치 확인
        {
            isPosDown = true;
            MovePosDown = false;
        }
        else
        {
            isPosDown = false;
        }

        if(transform.position.y == 4.5)
        {
            MovePosDown = false;
            MovePosUp = false;
        }

        if(transform.position.y >= 7.4) //위쪽 위치 확인
        {
            isPosUp = true;
            MovePosUp = false;
        }
        else
        {
            isPosUp = false;
        }

        if (transform.position.z >= 7.4) //왼쪽 위치 확인
        {
            isPosLeft = true;
            MovePosLeft = false;
        }
        else
        {
            isPosLeft = false;
        }

        if (transform.position.z == 4.5)
        {
            MovePosLeft = false;
            MovePosRight = false;
        }

        if (transform.position.z <= 1.6) //오른쪽 위치 확인
        {
            isPosRight = true;
            MovePosRight = false;
        }
        else
        {
            isPosRight = false;
        }


    }

    void PlayerInput()
    {
        //플레이어 위치이동 입력받는 함수
        //WASD로 조작, 움직임 딜레이 있음
        if(isPosUp == false)
        {
            if (Input.GetKeyDown(KeyCode.W) && MoveDelCurrent <= 0)
            {
                MovePosUp = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if(isPosDown == false)
        {
            if(Input.GetKeyDown(KeyCode.S) && MoveDelCurrent <= 0)
            {
                MovePosDown = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if (isPosLeft == false)
        {
            if (Input.GetKeyDown(KeyCode.A) && MoveDelCurrent <= 0)
            {
                MovePosLeft = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if (isPosRight == false)
        {
            if (Input.GetKeyDown(KeyCode.D) && MoveDelCurrent <= 0)
            {
                MovePosRight = true;
                MoveDelCurrent = MoveDel;
            }
        }
    }

    void PlayerMovement()
    {
        if (MovePosUp)
        {
            target = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);
        }

        if (MovePosDown) 
        {
            target = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);
        }


        if (MovePosLeft)
        {
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);
        }     

        if (MovePosRight)
        {
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);
        }
    }
}
