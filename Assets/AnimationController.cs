using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator animator;
   [SerializeField] float moveX;
   [SerializeField] float moveZ;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        if (moveZ == 1)
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkRight", 0);
            animator.SetInteger("WalkFront", 1);
        }
        else if (moveZ == -1)
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
            animator.SetInteger("WalkBack", 1);

        }
        
        if (moveX == 1)
        {
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
            animator.SetInteger("WalkLeft", 1);
        }
        else if (moveX == -1)
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 1);
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    animator.SetInteger("WalkBack", 0);
        //    animator.SetInteger("WalkFront", 0);
        //    animator.SetInteger("WalkRight", 0);
        //    animator.SetInteger("WalkLeft", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    animator.SetInteger("WalkLeft", 0);
        //    animator.SetInteger("WalkFront", 0);
        //    animator.SetInteger("WalkRight", 0);
        //    animator.SetInteger("WalkBack", 1);

        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    animator.SetInteger("WalkLeft", 0);
        //    animator.SetInteger("WalkBack", 0);
        //    animator.SetInteger("WalkRight", 0);
        //    animator.SetInteger("WalkFront", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    animator.SetInteger("WalkLeft", 0);
        //    animator.SetInteger("WalkBack", 0);
        //    animator.SetInteger("WalkFront", 0);
        //    animator.SetInteger("WalkRight", 1);
        //}
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
        }
        if (Input.GetMouseButton(0))
        {
            animator.SetInteger("Shoot", 1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetInteger("Shoot", 0);

        }
    }
}
