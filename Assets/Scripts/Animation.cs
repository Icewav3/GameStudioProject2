using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!SceneStateManager.gameIsPaused)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("IsMove", true);
            }
            else
            {
                animator.SetBool("IsMove", false);
            }
        }
    }
}

