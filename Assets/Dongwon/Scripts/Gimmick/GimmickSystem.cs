using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickSystem : MonoBehaviour
{
    public float SpawnWaringLineTimer; //감소하는 타이머
    public float SpawnTime = 10; //타이머 기준값
    public float playerMoveTimer;
    public float playerMoveTime = 5;

    public int W_Lineidx = 0;

    public bool PlayerNotMoving = false; //기믹시스템 스크립트에 있는 움직임 확인 boolean 변수

    public GameObject Player;
    public GameObject[] WarningLineTrm; //각 숫자별 위치를 받아오기 위한 리스트

    PlayerMove _playerMove;
    PlayerMoveForward _moveForward;

    Vector3 W_LineVec;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaringLineTimer = SpawnTime; //시작하고 타이머 설정
        playerMoveTimer = playerMoveTime; 

        _playerMove = FindObjectOfType<PlayerMove>();
        _moveForward = FindObjectOfType<PlayerMoveForward>();
    }

    // Update is called once per frame
    void Update()
    { 
        PlayerNotMoving = _playerMove.IsNotMoving; //플레이어 무브 스크립트의 움직임 감지 boolean 변수값을 저장

        if(!PlayerStatus.Instance.Death) //플레이어가 Death 상태가 아닐 경우
        {
            if(!PlayerStatus.Instance.Pause && !PlayerStatus.Instance.Clear) //게임이 퍼즈가 아닐 경우
            {
                SpawnWaringLineTimer -= Time.deltaTime;

                PlayerTrmCheck(); //플레이어가 제자리에서 5초동안 움직이지 않을경우 동작하는 함수
                TenSecSpawnSpear(); //10초마다 동작하는 기믹 시스템 함수
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    void TenSecSpawnSpear() //10초마다 랜덤한 위치에 경고라인, 이후 창 생성
    {
        if (SpawnWaringLineTimer <= 0) //타이머가 0이하일때 다음 함수 실행
        {
            W_Lineidx = Random.Range(0, 8); //W_Lineidx에 0~8 사이 int의 랜덤한 값 제공

            var warningLineGo = ObjectPoolManager.instance.GetGo("WarningLine"); //오브젝트풀

            switch (W_Lineidx)
            {
                case 0:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 1:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 2:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 3:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 4:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 5:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 6:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 7:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                case 8:
                    W_LineVec = new Vector3(Player.transform.position.x, WarningLineTrm[W_Lineidx].transform.position.y, WarningLineTrm[W_Lineidx].transform.position.z);
                    break;

                default:
                    break;
            } //W_Lineidx 값에 따라 지정된 위치의 포지션 값 받고

            warningLineGo.transform.position = W_LineVec; //생성한 풀링 오브젝트의 포지션 설정

            SpawnWaringLineTimer = SpawnTime; //타이머 초기화
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void PlayerTrmCheck() //플레이어가 움직이는지 아닌지 확인하고 동작하는 함수
    {
        if(PlayerNotMoving) //플레이어가 움직이지 않고 있다면
        {
            playerMoveTimer -= Time.deltaTime; //타이머 동작

            if(playerMoveTimer <= 0) //타이머가 0이 된다면
            {
                var warningLineGo = ObjectPoolManager.instance.GetGo("WarningLine"); //오브젝트 풀링

                Vector3 getVel = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z); //풀링된 오브젝트에 제공할 위치 Vector 설정

                warningLineGo.transform.position = getVel; //벡터값에 따라 위치 설정

                playerMoveTimer = playerMoveTime; //타이머 초기화
            }
        }

        else if(!PlayerNotMoving) //만약 플레이어가 움직인다면
        {
            playerMoveTimer = playerMoveTime; //타이머 초기화
        }
    }
}
