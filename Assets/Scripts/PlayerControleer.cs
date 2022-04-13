using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControleer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    [SerializeField]
        int speed;
    [SerializeField]
    int jumpF;

    [SerializeField]
    GameObject attackHitBox;


    bool isAttacking = false;

    //bool isGrounded; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        attackHitBox.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;

            

            animator.Play("player_attack1");


            StartCoroutine(DoAttack());
            //Invoke("ResetAttack", .5f);
        }
    }

    private void FixedUpdate()
    {
        //if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        //{
           // isGrounded = true;
       // }
       // else
        //{
           // isGrounded = false;
        //}


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            //if(isGrounded)
            if(!isAttacking)
            animator.Play("player_run");

            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //if(isGrounded)
            if(!isAttacking)
            animator.Play("player_run");
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            //if(isGrounded)
            if (!isAttacking)
            {
                animator.Play("player_idle");
            }
           
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpF);
            animator.Play("player_jump");
        }
    }


    IEnumerator DoAttack()
    {
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        attackHitBox.SetActive(false);

        isAttacking = false;
    }

    /*void ResetAttack()
    {
        isAttacking = false;
    }*/
}
