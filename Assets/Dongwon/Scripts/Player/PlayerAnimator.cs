using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatus.Instance.Pause || PlayerStatus.Instance.Death)
        {
            OnDeathAnimation();
        }
    }

    void OnDeathAnimation()
    {
        animator.SetBool("OnDeath", true);
    }
}