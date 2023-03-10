using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 0;
    Rigidbody2D r2d;
    float inputX, inputY, distance;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    public Animator animator;
    public Enemy enemy;
    [SerializeField]
    private DuelUI ui;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, enemy.transform.position);
        animator.SetFloat("speed", Mathf.Abs(speed));
        enemy.animator.SetFloat("distance", Mathf.Abs(distance));

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Movement();
        Attack();


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
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("clicked", true);
           
            if(distance < 2f)
            {
                enemy.animator.SetBool("hurt", true);
            }

        }
        else
        {
            animator.SetBool("clicked", false);
            enemy.animator.SetBool("hurt", false);     
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.animator.SetBool("enemyClose", true);
            animator.SetBool("enemyAttack", true);
            ui.playerLifeManager();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.animator.SetBool("enemyClose", false);
        animator.SetBool("enemyAttack", false);
    }


}
