using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D r2d;
    public float speed;
    public Transform player;
    private SpriteRenderer sRenderer;
    public Animator animator;
    bool faceLeft = true;
    public Knight knight;

    public void Awake()
    {
        this.sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("speed", Mathf.Abs(speed));
        flip();
        move();
        this.sRenderer.flipX = player.transform.position.x > this.transform.position.x;

    }


    void move()
    {
        r2d.velocity = new Vector2(speed * Time.fixedDeltaTime, r2d.velocity.y);
        if (player.transform.position.x > this.transform.position.x)
        {
            speed = 50;
        }
        else
        {
            speed = -50;
        }
    }

    void flip()
    {
        if (!faceLeft)
        {
            speed *= -1;
            Vector3 enemyScale = transform.localScale;
            enemyScale.x *= -1;
            transform.localScale = enemyScale;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetBool("enemyClose", true);
            knight.animator.SetBool("enemyAttack", true);  
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("enemyClose", false);
        knight.animator.SetBool("enemyAttack", false);
    }

}
