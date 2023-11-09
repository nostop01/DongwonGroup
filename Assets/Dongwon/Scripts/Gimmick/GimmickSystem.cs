using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickSystem : MonoBehaviour
{
    public float SpawnWaringLineTimer; //�����ϴ� Ÿ�̸�
    public float SpawnTime = 10; //Ÿ�̸� ���ذ�
    public float playerMoveTimer;
    public float playerMoveTime = 5;

    public int W_Lineidx = 0;

    public bool PlayerNotMoving = false;

    public GameObject Player;
    public GameObject[] WarningLineTrm; //�� ���ں� ��ġ�� �޾ƿ��� ���� ����Ʈ

    PlayerMove _playerMove;

    Vector3 W_LineVec;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaringLineTimer = SpawnTime; //�����ϰ� Ÿ�̸� ����
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

    void TenSecSpawnSpear() //10�ʸ��� ������ ��ġ�� �������, ���� â ����
    {
        if (SpawnWaringLineTimer <= 0) //Ÿ�̸Ӱ� 0�����϶� ���� �Լ� ����
        {
            W_Lineidx = Random.Range(0, 8); //W_Lineidx�� 0~8 ���� int�� ������ �� ����

            var warningLineGo = ObjectPoolManager.instance.GetGo("WarningLine"); //������ƮǮ

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
            } //W_Lineidx ���� ���� ������ ��ġ�� ������ �� �ް�

            warningLineGo.transform.position = W_LineVec; //������ Ǯ�� ������Ʈ�� ������ ����

            SpawnWaringLineTimer = SpawnTime; //Ÿ�̸� �ʱ�ȭ

            StartCoroutine(WaitTime(0.5f)); //0.5�� ���
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