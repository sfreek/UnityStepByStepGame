using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    bool isShacking = false;
    float shake = .2f;
    Vector2 pos;

    [SerializeField]
    int health = 3;

    [SerializeField]
    Object destructable;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShacking == true)
        {
            transform.position = pos + UnityEngine.Random.insideUnitCircle * shake;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag( "Weapon"))
        {
            isShacking = true;
            health--;
            if (health <= 0)
            {
                ExplodeTheObject();
            }
            Invoke("StopShaking", .5f);
        }
    }

    void StopShaking()
    {
        isShacking = false;
        transform.position = pos;
    }

    void ExplodeTheObject()
    {
        GameObject destruct = (GameObject)Instantiate(destructable);
        destruct.transform.position = transform.position;

        Destroy(gameObject);
    }
}
