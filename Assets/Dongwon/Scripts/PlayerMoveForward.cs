using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool CanMove = true; //게임오버가 아닐 때, 게임이 끝나지 않았을 때 움직이도록 하는 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove) //움직일 수 있는 상태일때
        {
            transform.Translate(new Vector3(0.0f, MoveSpeed * Time.deltaTime, 0.0f)); //무조건 앞으로 나아감
        }
    }
}
