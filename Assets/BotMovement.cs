using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public float walkSpeed;

    /* public float speed;
     private float waitTime;
     public float startWaitTime;

     public Transform moveSpot;
     public float minX;
     public float maxX;
     public float minY;
     public float maxY;*/
    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;



    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    void Start()
    {
        mustPatrol = true;
        //waitTime = startWaitTime;//for????
       // moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

  
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f,groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true; 
    }
}
