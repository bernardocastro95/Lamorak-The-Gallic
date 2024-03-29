﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFight : MonoBehaviour
{
    public float speed = 0;
    Rigidbody2D r2d;
    float inputX, inputY;
    public float distance;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    public Animator animator;
    public Dragon dragon;
    public bool isClicked = false;
    [SerializeField]
    private FinalDuelUI fui;
    public bool injured = false, ok = true;
    public float timer;
    // Start is called before the first frame update
    public void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        distance = Vector3.Distance(dragon.transform.position, transform.position);
        animator.SetFloat("speed", Mathf.Abs(speed));
        dragon.animator.SetFloat("distance", Mathf.Abs(distance));

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        timer += Time.deltaTime;

        Attack();
        Movement();
        

        if(timer > 7 && injured == true)
        {
            Heal();
        }
        



        if (gm.paused == true || gm.isGameOver == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    void FixedUpdate()
    {
        r2d.velocity = new Vector2(speed * inputX, speed * inputY);

    }



    void Movement()
    {
        if (gm.gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                speed += 10;
                gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1f);
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed = 0;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                speed += 10;
                gameObject.transform.localScale = new Vector3(-1.8f, 1.8f, 1f);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                speed = 0;
            }

        }

    }
    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && distance < 4)
        {
            isClicked = true;
            animator.SetBool("clicked", true);
            dragon.animator.SetBool("hurt", true);


        }
        else
        {
            isClicked = false;
            animator.SetBool("clicked", false);
            dragon.animator.SetBool("hurt", false);
            
        }
    }

    void Heal()
    {
        timer = 0;
        ok = true;
        injured = false;
        animator.SetBool("injured", false);
        animator.SetBool("ok", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FireBall")
        {
            ok = false;
            injured = true;
            animator.SetBool("injured", true);
            animator.SetBool("ok", false);
            fui.playerLifeManager();

        }
        
    }



}
