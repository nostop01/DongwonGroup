using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isPosUp = false; //�� �����Ǹ��� boolean ���� ����
    public bool isPosDown = false;
    public bool isPosLeft = false;
    public bool isPosRight = false;

    public bool MovePosUp = false; //�� ���� �� �����̴������� Ȯ���ϱ� ���� boolean ���� ����
    public bool MovePosDown = false;
    public bool MovePosLeft = false;
    public bool MovePosRight = false;

    public bool IsNotMoving = false; //�������� �ִ��� ������ �����ϴ� ����

    public float LerpSpeed = 0.5f;
    public float RotLerpSpeed = 0.25f;

    private float MoveDel = 0.15f; //������ ��Ÿ��
    private float MoveDelCurrent = 0.15f; //������ ��Ÿ�� ���� ����

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
        if(!PlayerStatus.Instance.Death) //�÷��̾ ���� �ʾҰ�
        {
            if(!PlayerStatus.Instance.Pause) //������ ������°� �ƴ� ��
            {
                MoveDelCurrent -= Time.deltaTime; //�÷��̾� ������ ������ Ÿ�̸�
                CheckPlayerPos(); //�÷��̾� ��ġ�� Ȯ���ϴ� �Լ�
                PlayerInput(); //�÷��̾� �Է� �޴� �Լ�
                PlayerMovement(); //�÷��̾� �����̰� �ϴ� �Լ�
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    void CheckPlayerPos()
    {
        //�÷��̾� ��ġ �ǽð� üũ
        if(transform.position.y <= TrmPos.transform.position.y - 3) //�Ʒ��� ��ġ Ȯ���ؼ�
        {
            //�Ʒ��� ���� ���
            isPosDown = true; //�Ʒ����̶�� ���ϴ� boolean ���� true
            MovePosDown = false; //�Ʒ� �����̸� �������� ������ �����̴� boolean ���� false;
        }
        else
        {
            //�Ʒ��� ���� ���
            isPosDown = false; //�Ʒ���  boolean ���� false
        }

        if(transform.position.y == TrmPos.transform.position.y) //���� ����� ������
        {
            MovePosDown = false; //�Ʒ��� boolean������
            MovePosUp = false; //���� boolean ���� false
        }

        if(transform.position.y >= TrmPos.transform.position.y + 3) //���� ��ġ Ȯ��
        {
            //�Ʒ��� ��ġ Ȯ���ϴ� �Լ��� ����
            isPosUp = true;
            MovePosUp = false;
        }
        else
        {
            isPosUp = false;
        }

        if (transform.position.z >= TrmPos.transform.position.z + 3) //���� ��ġ Ȯ���ؼ�
        {
            //���ʿ� ���� ���
            isPosLeft = true; //���ʿ� �ִٴ� boolean���� true 
            MovePosLeft = false; //���� �����̸� �������� ������ �����δٴ� boolean ���� false
        }
        else
        {
            //���ʿ� ���� ���
            isPosLeft = false; //���ʿ� �ִٴ� boolean ���� false
        }

        if (transform.position.z == TrmPos.transform.position.z) //���� ���ʰ� �������� ���̿�(�����)�ִٸ�
        {
            MovePosLeft = false; //���� boolean������
            MovePosRight = false; //������ boolean �Լ� false
        }

        if (transform.position.z <= TrmPos.transform.position.z - 3) //������ ��ġ Ȯ��
        {
            //���� ��ġ Ȯ�� ������ ����
            isPosRight = true;
            MovePosRight = false;
        }
        else
        {
            isPosRight = false;
        }


    }

    void PlayerInput() //������ �Է¹ޱ�
    {
        //�÷��̾� ��ġ�̵� �Է¹޴� �Լ�
        //WASD�� ����, ������ ������ ����
        if(!isPosUp && !MovePosDown) //�÷��̾� ��ġ�� ���ʿ� ���� ��
        {
            if (Input.GetKeyDown(KeyCode.W) && MoveDelCurrent <= 0) //�������� �̵��϶�� �Է��� �޾Ұ�, ������ �����̰��� 0�̶� �̵��� ������ ��
            {
                MovePosUp = true; //�������� �̵��Ѵٴ� boolean ���� true�� �ٲٰ�
                MoveDelCurrent = MoveDel; //������ ������ Ÿ�̸� �ʱ�ȭ
            }
        }

        if(!isPosDown && !MovePosUp) //���� ����
        {
            if(Input.GetKeyDown(KeyCode.S) && MoveDelCurrent <= 0)
            {
                MovePosDown = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if (!isPosLeft && !MovePosRight) //���� ����
        {
            if (Input.GetKeyDown(KeyCode.A) && MoveDelCurrent <= 0)
            {
                MovePosLeft = true;
                MoveDelCurrent = MoveDel;
            }
        }

        if (!isPosRight && !MovePosLeft)//���� ����
        {
            if (Input.GetKeyDown(KeyCode.D) && MoveDelCurrent <= 0)
            {
                MovePosRight = true;
                MoveDelCurrent = MoveDel;
            }
        }
    }

    void PlayerMovement() //�����̰� �ϴ� �Լ�
    {
        if (MovePosUp) //�������� �̵����̶�� boolean ������ true�� ��
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z); //�������� �̵��ϴ� ���� ����
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed); //���� ��ġ�� �̵��� ���Ͱ��� ����(Lerp)�Ͽ� �̵���Ŵ

            Quaternion targetRot = Quaternion.Euler(-25, 90, 0); //�̵��� �ڿ������� �ϱ� ���� �̵��ϴ� ������ �ٶ󺸰� �ϴ� ���ʹϾ� ����
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed); //���� ������ �ٶ� ���ʹϾ� ���� ����(Lerp)�Ͽ� ȸ��
        }

        if (MovePosDown) //�Ʒ������� �̵����̶�� boolean ������ true�� ��
        {
            //���� ����
            Vector3 target = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);

            Quaternion targetRot = Quaternion.Euler(25, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed);
        }

        if (MovePosLeft) //�������� �̵����̶�� boolean ������ true�� ��
        {
            //���� ����
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);

            Quaternion targetRot = Quaternion.Euler(0, 65, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed);
        }

        if (MovePosRight) //���������� �̵����̶�� boolean ������ true�� ��
        {
            //���� ����
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            transform.position = Vector3.Lerp(transform.position, target, LerpSpeed);

            Quaternion targetRot = Quaternion.Euler(0, 115, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed);
        }

        if (!MovePosRight && !MovePosDown && !MovePosUp && !MovePosLeft) //���� ���ε� �̵������� �ʴٸ�
        {
            Quaternion targetRot = Quaternion.Euler(0, 90, 0); //������ �ٶ󺸰� ���ʹϾ� ����
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, RotLerpSpeed); //�ٶ󺸴� ����� ������ ���ʹϾ��� ����(Lerp)�Ͽ� ȸ��

            IsNotMoving = true; //�������� ���� ������ true�� �� ��ȯ
        }

        else
        {
            IsNotMoving = false; //�ƴ� ��� �����̴°ű� ������ false�� �� ��ȯ
        }
    }
}