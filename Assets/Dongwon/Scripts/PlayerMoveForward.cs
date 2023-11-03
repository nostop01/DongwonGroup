using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool CanMove = true; //���ӿ����� �ƴ� ��, ������ ������ �ʾ��� �� �����̵��� �ϴ� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove) //������ �� �ִ� �����϶�
        {
            transform.Translate(new Vector3(0.0f, MoveSpeed * Time.deltaTime, 0.0f)); //������ ������ ���ư�
        }
    }
}