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
        flip(); 
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
        flip();
        r2d.velocity = new Vector2(speed * Time.fixedDeltaTime, r2d.velocity.y);
    }
    void flip()
    {
        if(gameObject.transform.position.x == 0)
        {
            speed = speed * -1;
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if(gameObject.transform.position.x == 7.8)
        {
            speed = speed * -1;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
