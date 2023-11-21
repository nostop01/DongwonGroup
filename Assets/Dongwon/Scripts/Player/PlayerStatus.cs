using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public bool CanMove = true;    //게임오버가 아닐 때, 게임이 끝나지 않았을 때 움직이도록 하는 변수
    [SerializeField]
    public bool CollideObstacle = false;    //오브젝트에 부딫혔는지 아닌지 확인하는 boolean변수
    [SerializeField]
    public bool Death = false;     //플레이어 상태 확인하는 변수
    [SerializeField]
    public bool Pause = false;     //게임오버, 게임이 끝났거나, 게임이 일시중지 되었을 때, 시작하기 전에 사용하는 변수
    [SerializeField]
    public bool Clear = false;

    GameManager gameManager;

    static PlayerStatus instance;

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
