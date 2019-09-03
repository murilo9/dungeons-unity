using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canMove = true;
    private bool moving = false;
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(change != Vector3.zero && canMove)       //Check if movement key is pressed
        {
            if (!moving)
            {
                moving = true;
                animator.SetTrigger("doWalk");      //Start walk animation
            }
            MoveCharacter();    //Move on space
        }
        else        //If no movement key is pressed
        {
            if (moving)
            {
                moving = false;
                animator.SetTrigger("stopWalk");
            }
        }
    }

    void MoveCharacter()
    {
        rigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
