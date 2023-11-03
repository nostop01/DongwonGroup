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

    public bool MovePosUp = false;
    public bool MovePosDown = false;
    public bool MovePosLeft = false;
    public bool MovePosRight = false;

    public float LerpSpeed = 0.025f;

    private float MoveDel = 0.35f; //������ ��Ÿ��
    private float MoveDelCurrent = 0.35f; //������ ��Ÿ�� ���� ����

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

        MoveDelCurrent -= Time.deltaTime; //����� ���� �� 0���� �����
    }

    void CheckPlayerPos()
    {
        //�÷��̾� ��ġ �ǽð� üũ
        if(transform.position.y <= 1.6) //�Ʒ��� ��ġ Ȯ��
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

        if(transform.position.y >= 7.4) //���� ��ġ Ȯ��
        {
            isPosUp = true;
            MovePosUp = false;
        }
        else
        {
            isPosUp = false;
        }

        if (transform.position.z >= 7.4) //���� ��ġ Ȯ��
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

        if (transform.position.z <= 1.6) //������ ��ġ Ȯ��
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
        //�÷��̾� ��ġ�̵� �Է¹޴� �Լ�
        //WASD�� ����, ������ ������ ����
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