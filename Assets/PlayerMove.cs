using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float speed = 3;

    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Move();
    }

    private void Move()
    {
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }
}
