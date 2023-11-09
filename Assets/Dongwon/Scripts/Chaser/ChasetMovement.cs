using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasetMovement : MonoBehaviour
{
    public float MoveSpeed = 4.5f;

    public bool GamePause = false;

    public GameObject Player;

    PlayerMoveForward _moveForward;
    Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _moveForward = FindObjectOfType<PlayerMoveForward>();
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GamePause = _moveForward.Pause;

        ChaserMove();
    }

    void ChaserMove()
    {
        if (!GamePause)
        {
            Vector3 getVel = new Vector3(MoveSpeed, 0,0);

            _rigid.velocity = getVel;

            transform.position = new Vector3(transform.position.x, Player.transform.position.y, Player.transform.position.z);
        }
    }
}
