using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2d : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float movingSpeed;

    private void Awake()
    {
        this.transform.position = new Vector3()
        {
            x = this.player.position.x,
            y = this.player.position.y,
            z = this.player.position.z - 10,
        };
    }
    private void Update()
    {
        Vector3 target = new Vector3()
        {
            x = player.position.x,
            y = this.player.position.y,
            z = this.player.position.z - 10,
        };
        Vector3 pos = Vector3.Lerp(this.transform.position,target,this.movingSpeed*Time.deltaTime);
        this.transform.position = pos;
    }
}
