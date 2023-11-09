using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    public float StoneHitMoveSpeed = 4.5f; //�� ��ֹ��� �浹���� �� �ӵ�
    public float SharkHitMoveSpeed = 4.25f; //��� ��ֹ��� �浹���� �� �ӵ�
    public float SeaweedHitMoveSpeed = 3.75f; //���� ��ֹ��� �浹���� �� �ӵ�

    public float SharkObstacleMoveSpeed = 2.5f; //��� ��ֹ��� �̵��ϴ� �ӵ�

    public bool SharkObstacle = false; //��� ��ֹ����� �ƴ��� Ȯ���ϴ� boolean ����

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
        if(SharkObstacle) //���� ��� ��ֹ��� ���
        {
            Vector3 getVel = new Vector3(-SharkObstacleMoveSpeed, 0, 0); //�÷��̾ �����̴� ������ �ݴ� �������� ���Ͱ� ����
            _rigid.velocity = getVel; //������ٵ��� ���ν�Ƽ ���Ϳ� ������ ���Ͱ� ����
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") //���� �÷��̾�� �̸��� ���� ������Ʈ�� �浹 ��
        {
            Destroy(gameObject); //�� ��ֹ� ������Ʈ�� ����
        }
    }
}