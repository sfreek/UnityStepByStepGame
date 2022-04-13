using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove1 : MonoBehaviour
{
    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;
 


        
    public Rigidbody2D rb;
   
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
   
    void Patrol()
    {
        
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

