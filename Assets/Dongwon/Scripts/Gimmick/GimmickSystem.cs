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

    public bool PlayerNotMoving = false;

    public GameObject Player;
    public GameObject[] WarningLineTrm; //각 숫자별 위치를 받아오기 위한 리스트

    PlayerMove _playerMove;

    Vector3 W_LineVec;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaringLineTimer = SpawnTime; //시작하고 타이머 설정
        playerMoveTimer = playerMoveTime;

        _playerMove = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWaringLineTimer -= Time.deltaTime;

        PlayerTrmCheck();
        TenSecSpawnSpear();

        PlayerNotMoving = _playerMove.IsNotMoving;
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

            StartCoroutine(WaitTime(0.5f)); //0.5초 대기
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void PlayerTrmCheck()
    {
        if(PlayerNotMoving)
        {
            playerMoveTimer -= Time.deltaTime;

            if(playerMoveTimer <= 0)
            {
                var warningLineGo = ObjectPoolManager.instance.GetGo("WarningLine");

                Vector3 getVel = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

                warningLineGo.transform.position = getVel;

                playerMoveTimer = playerMoveTime;
            }
        }

        else if(!PlayerNotMoving)
        {
            playerMoveTimer = playerMoveTime;
        }
    }
}
