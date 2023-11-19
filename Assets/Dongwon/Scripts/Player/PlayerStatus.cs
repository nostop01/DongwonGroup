using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public bool CanMove = true;    //���ӿ����� �ƴ� ��, ������ ������ �ʾ��� �� �����̵��� �ϴ� ����
    [SerializeField]
    public bool CollideObstacle = false;    //������Ʈ�� �΋H������ �ƴ��� Ȯ���ϴ� boolean����
    [SerializeField]
    public bool Death = false;     //�÷��̾� ���� Ȯ���ϴ� ����
    [SerializeField]
    public bool Pause = false;     //���ӿ���, ������ �����ų�, ������ �Ͻ����� �Ǿ��� ��, �����ϱ� ���� ����ϴ� ����
    [SerializeField]
    public bool Clear = false;

    GameManager gameManager;

    private static PlayerStatus instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }

        else
        {
            Destroy(gameObject);
        }

        CanMove = true;
        CollideObstacle = false;
        Death = false;
        Pause = false;
        Clear = false;

    }

    public static PlayerStatus Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }

            return instance;
        }
    }
 
    void Start()
    {
        CanMove = true;
        CollideObstacle = false;
        Death = false;
        Pause = false;
        Clear = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public void OnDeath()
    {
        Death = true;
        CanMove = false;
    }

    public void OnPause()
    {
        Pause = true;
    }

    public void OnCannotMove()
    {
        CanMove = false;
    }

    public void HitObstacle()
    {
        CollideObstacle = true;
    }

    public void OnClear()
    {
        Clear = true;
    }
}