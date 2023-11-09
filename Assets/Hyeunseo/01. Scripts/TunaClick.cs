using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaClick : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    animator.SetBool("Click", true);
                    Invoke("ClickEvent", 0.1f);
                }
            }
        }
    }

    void ClickEvent()
    {
        animator.SetBool("Click", false);
    }
}
