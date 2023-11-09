using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public bool GamePause = false; //������ �������� �ƴ��� Ȯ���ϴ� ����
    
    Animator animator;
    PlayerMoveForward _moveForward;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _moveForward = FindObjectOfType<PlayerMoveForward>();
    }

    // Update is called once per frame
    void Update()
    {
        GamePause = _moveForward.Pause;

        if(GamePause)
        {

        }

        OnDeathAnimation();
    }

    void OnDeathAnimation()
    {
        if(_moveForward.Death)
        {
            animator.SetBool("OnDeath", true);
        }
    }
}