using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target
        ;  

    public float speed = 2f;
    private Rigidbody2D gsrbd2;
    private Vector2 moveDirection;
    private void Start()
    {
        gsrbd2 = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;

    }
    void Update()
    {
    
          Vector2 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
     
       
    }
    private void FixedUpdate()
    {
        gsrbd2.velocity = new Vector2(moveDirection.x, gsrbd2.velocity.y) * speed;
    }
}

