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

    public bool PlayerNotMoving = false; //��ͽý��� ��ũ��Ʈ�� �ִ� ������ Ȯ�� boolean ����
    public bool PlayerStatus = false; //�÷��̾� ���� �޾ƿ���
    public bool GamePause = false; //������ ����������� �޾ƿ��� ���� ����

    public GameObject Player;
    public GameObject[] WarningLineTrm; //�� ���ں� ��ġ�� �޾ƿ��� ���� ����Ʈ

    PlayerMove _playerMove;
    PlayerMoveForward _moveForward;

    Vector3 W_LineVec;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaringLineTimer = SpawnTime; //�����ϰ� Ÿ�̸� ����
        playerMoveTimer = playerMoveTime; 

        _playerMove = FindObjectOfType<PlayerMove>();
        _moveForward = FindObjectOfType<PlayerMoveForward>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWaringLineTimer -= Time.deltaTime;

        PlayerNotMoving = _playerMove.IsNotMoving; //�÷��̾� ���� ��ũ��Ʈ�� ������ ���� boolean �������� ����
        PlayerStatus = _moveForward.Death; //�÷��̾ ���� �������� �ƴ��� ����
        GamePause = _moveForward.Pause; //������ �������� �ƴ��� Ȯ��

        if(!PlayerStatus) //�÷��̾ Death ���°� �ƴ� ���
        {
            if(!GamePause) //������ ��� �ƴ� ���
            {
                PlayerTrmCheck(); //�÷��̾ ���ڸ����� 5�ʵ��� �������� ������� �����ϴ� �Լ�
                TenSecSpawnSpear(); //10�ʸ��� �����ϴ� ��� �ý��� �Լ�
            }
        }
    }

    private void FixedUpdate()
    {
        
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
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void PlayerTrmCheck() //�÷��̾ �����̴��� �ƴ��� Ȯ���ϰ� �����ϴ� �Լ�
    {
        if(PlayerNotMoving) //�÷��̾ �������� �ʰ� �ִٸ�
        {
            playerMoveTimer -= Time.deltaTime; //Ÿ�̸� ����

            if(playerMoveTimer <= 0) //Ÿ�̸Ӱ� 0�� �ȴٸ�
            {
                var warningLineGo = ObjectPoolManager.instance.GetGo("WarningLine"); //������Ʈ Ǯ��

                Vector3 getVel = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z); //Ǯ���� ������Ʈ�� ������ ��ġ Vector ����

                warningLineGo.transform.position = getVel; //���Ͱ��� ���� ��ġ ����

                playerMoveTimer = playerMoveTime; //Ÿ�̸� �ʱ�ȭ
            }
        }

        else if(!PlayerNotMoving) //���� �÷��̾ �����δٸ�
        {
            playerMoveTimer = playerMoveTime; //Ÿ�̸� �ʱ�ȭ
        }
    }
}