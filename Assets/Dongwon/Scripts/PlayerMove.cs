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

    public bool MovePosUp = false; //각 방향 별 움직이는중인지 확인하기 위한 boolean 변수 제공
    public bool MovePosDown = false;
    public bool MovePosLeft = false;
    public bool MovePosRight = false;

    public bool IsNotMoving = false; //움직임이 있는지 없는지 감지하는 변수
    public bool PlayerStatus = false; //플레이어가 Death 상태인지 아닌지 확인하는 변수
    public bool GamePause = false; //게임이 퍼즈상태인지 아닌지 확인하는 변수

    public float LerpSpeed = 0.5f;
    public float RotLerpSpeed = 0.25f;

    private float MoveDel = 0.15f; //움직임 쿨타임
    private float MoveDelCurrent = 0.15f; //움직임 쿨타임 적용 변수

    public GameObject TrmPos;

    PlayerMoveForward _moveForward;

    // Start is called before the first frame update
    void Start()
    {
        _moveForward = FindObjectOfType<PlayerMoveForward>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerStatus) //플레이어가 죽지 않았고
        {
            if(!GamePause) //게임이 퍼즈상태가 아닐 때
            {
                MoveDelCurrent -= Time.deltaTime; //플레이어 움직임 딜레이 타이머
                CheckPlayerPos(); //플레이어 위치를 확인하는 함수
                PlayerInput(); //플레이어 입력 받는 함수
                PlayerMovement(); //플레이어 움직이게 하는 함수
            }
        }

        PlayerStatus = _moveForward.Death;
        GamePause = _moveForward.Pause;
    }

    private void FixedUpdate()
    {
        
    }

    void CheckPlayerPos()
    {
        //플레이어 위치 실시간 체크
        if(transform.position.y <= TrmPos.transform.position.y - 3) //아래쪽 위치 확인해서
        {
            //아래에 있을 경우
            isPosDown = true; //아래쪽이라고 말하는 boolean 변수 true
            MovePosDown = false; //아래 도착이면 움직이지 않으니 움직이는 boolean 변수 false;
        }
        else
        {
            //아래에 없을 경우
            isPosDown = false; //아래쪽  boolean 변수 false
        }

        if(transform.position.y == TrmPos.transform.position.y) //만약 가운데에 멈출경우
        {
            MovePosDown = false; //아래쪽 boolean변수랑
            MovePosUp = false; //위쪽 boolean 변수 false
        }

        if(transform.position.y >= TrmPos.transform.position.y + 3) //위쪽 위치 확인
        {
            //아래쪽 위치 확인하는 함수랑 동일
            isPosUp = true;
            MovePosUp = false;
        }
        else
        {
            isPosUp = false;
        }

        if (transform.position.z >= TrmPos.transform.position.z + 3) //왼쪽 위치 확인해서
        {
            //왼쪽에 있을 경우
            isPosLeft = true; //왼쪽에 있다는 boolean변수 true 
            MovePosLeft = false; //왼쪽 도착이면 움직이지 않으니 움직인다는 boolean 변수 false
        }
        else
        {
            //왼쪽에 없을 경우
            isPosLeft = false; //왼쪽에 있다는 boolean 변수 false
        }

        if (transform.position.z == TrmPos.transform.position.z) //만약 왼쪽과 오른쪽의 사이에(가운데에)있다면
        {
            MovePosLeft = false; //왼쪽 boolean변수와
            MovePosRight = false; //오른쪽 boolean 함수 false
        }

        if (transform.position.z <= TrmPos.transform.position.z - 3) //오른쪽 위치 확인
        {
            //왼쪽 위치 확인 변수와 동일
            isPosRight = true;
            MovePosRight = false;
        }
        else
        {
            isPosRight = false;
        }


    }

    void PlayerInput() //움직임 입력받기
    {
        //플레이어 위치이동 입력받는 함수
        //WASD로 조작, 움직임 딜레이 있음
        if(isPosUp == false) //플레이어 위치가 위쪽에 없을 때
        {
            if (Input.GetKeyDown(KeyCode.W) && MoveDelCurrent <= 0) //위쪽으로 이동하라는 입력을 받았고, 움직임 딜레이값이 0이라 이동이 가능할 때
            {
                MovePosUp = true; //위쪽으로 이동한다는 boolean 변수 true로 바꾸고
                MoveDelCurrent = MoveDel; //움직임 딜레이 타이머 초기화
            }
        }

        if(isPosDown == false) //이하 동일
        {
            if(Input.GetKeyDown(KeyCode.S) && MoveDelCurrent <= 0)
            {
                MovePosDown = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if (isPosLeft == false) //이하 동일
        {
            if (Input.GetKeyDown(KeyCode.A) && MoveDelCurrent <= 0)
            {
                MovePosLeft = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if (isPosRight == false)//이하 동일
        {
            if (Input.GetKeyDown(KeyCode.D) && MoveDelCurrent <= 0)
            {
                MovePosRight = true;
                MoveDelCurrent = MoveDel;
            }
        }
    }

    void PlayerMovement() //움직이게 하는 함수
    {
        if (MovePosUp) //위쪽으로 이동중이라는 boolean 변수가 true일 때
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z); //위쪽으로 이동하는 벡터 설정
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed); //현재 위치와 이동할 벡터값을 보간(Lerp)하여 이동시킴

            Quaternion targetRot = Quaternion.Euler(-25, 90, 0); //이동을 자연스럽게 하기 위해 이동하는 방향을 바라보게 하는 쿼터니언 설정
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed); //현재 각도와 바라볼 쿼터니언 값을 보간(Lerp)하여 회전
        }

        if (MovePosDown) //아래쪽으로 이동중이라는 boolean 변수가 true일 때
        {
            //이하 동일
            Vector3 target = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);

            Quaternion targetRot = Quaternion.Euler(25, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed);
        }

        if (MovePosLeft) //왼쪽으로 이동중이라는 boolean 변수가 true일 때
        {
            //이하 동일
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);

            Quaternion targetRot = Quaternion.Euler(0, 65, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed);
        }

        if (MovePosRight) //오른쪽으로 이동중이라는 boolean 변수가 true일 때
        {
            //이하 동일
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);

            Quaternion targetRot = Quaternion.Euler(0, 115, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed);
        }

        if (!MovePosRight && !MovePosDown && !MovePosUp && !MovePosLeft) //만약 어디로도 이동중이지 않다면
        {
            Quaternion targetRot = Quaternion.Euler(0, 90, 0); //정면을 바라보게 쿼터니언값 설정
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed); //바라보던 방향과 설정한 쿼터니언값을 보간(Lerp)하여 회전

            IsNotMoving = true; //움직임이 없기 때문에 true로 값 변환
        }

        else
        {
            IsNotMoving = false; //아닐 경우 움직이는거기 때문에 false로 값 변환
        }
    }
}
