using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public bool patrol;
    public Rigidbody2D r2d;
    public float speed;
    public Animator animator;
    public Transform groundChecker;
    private bool turn;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        patrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol)
        {
            animator.SetFloat("speed", Mathf.Abs(speed));
            move();
        }
    }

    private void FixedUpdate()
    {
        if (patrol)
        {
            turn = !Physics2D.OverlapCircle(groundChecker.position, 0.1f, groundLayer);
        }
    }

    void move()
    {
        if (turn)
        {
            flip();
        }
        r2d.velocity = new Vector2(speed * Time.fixedDeltaTime, r2d.velocity.y);
    }
    void flip()
    {
        patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        patrol = true;
    }
}
