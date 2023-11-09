using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMove : PoolAble
{
    public float MoveSpeed = 100f; //â �ӵ�
     
    public float destroyTimer; //������Ʈ ��ȯ�� ���� Ÿ�̸�
    public float destroyTime = 2; //������Ʈ ��ȯ Ÿ�̸� ���ذ�

    Rigidbody _rigid;

    PlayerMoveForward _moveForward;

    // Start is called before the first frame update
    void OnEnable() //������Ʈ Ȱ��ȭ �Ǿ��� ��
    {
        _rigid = GetComponent<Rigidbody>(); //������ٵ� ������Ʈ �޾ƿ���
        _moveForward = FindObjectOfType<PlayerMoveForward>(); //PlayerMoveForward ������Ʈ�� �ִ� ������Ʈ ã��

        Vector3 getVel = new Vector3(MoveSpeed, 0, 0); //����3 �� X ���Ϳ� â �ӵ� �ְ�
        _rigid.AddForce(getVel, ForceMode.Impulse); // getVel ���͸�ŭ ���� ���� ������ ȿ�� ����

        destroyTimer = destroyTime; //Ÿ�̸� ���ذ� �ݿ�
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime; //Ÿ�̸� ����

        if(destroyTimer <= 0) //Ÿ�̸Ӱ� 0 ������ ��
        {
            ReleaseObject(); //������Ʈ ��ȯ�ϰ�
            Vector3 getVel = Vector3.zero; //getVel�� ���� 0,0,0 �� �ο�
            _rigid.velocity = getVel; //������ٵ� ���Ͱ��� 0,0,0���� ������ ������Ʈ Ǯ ���� �ٽ� �����Ǿ��� �� �ӵ��� �þ�� ��� ����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") //�÷��̾� �̸��� ���� ������Ʈ�� �΋H�� ��
        {
            _moveForward.CanMove = false; //ã�Ƶ� ��ũ��Ʈ ������Ʈ�� CanMove�� false��
            //_moveForward._rigid.velocity = Vector3.zero; //������Ʈ�� ã�Ƶ� �ű� ������ ������Ʈ�� ������ٵ��� ���Ͱ��� 0,0,0���� ����(��� ���߰�)
            _moveForward.OnDeath(); //â ����� ��� �����̱� ������ OnDeath�� ���� �׾����� ����.
        }
    }
}