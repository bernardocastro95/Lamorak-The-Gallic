using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour


{


    public float speed = 0;
    Rigidbody2D r2d;
    float inputX, inputY;
    [SerializeField]
    GameManager gm;
    Vector3 respawn;
    public GameObject fallDetector;
    public float jumpForce;
    public Animator animator;
    Level2PauseMenu ui;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        respawn = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("GroundSpeed", Mathf.Abs(speed));

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Movement();
        Jump();
        

        if(gm.paused == true || gm.isGameOver == true)
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
                gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed = 0;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                speed += 10;
                gameObject.transform.localScale = new Vector3(-.5f, .5f, .5f);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                speed = 0;
            }

        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("jumpButtonClicked", true);
            r2d.AddForce(transform.up * jumpForce);
        }
        else
        {
            animator.SetBool("jumpButtonClicked", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Begin")
        {
            transform.position = respawn;
        }
        if(collision.gameObject.tag == "FinishFlag")
        {
            SceneManager.LoadScene(5);
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            speed = speed / 2;
        }
        else if (collision.gameObject.tag != "Obstacle")
        {
            speed = speed * 2;
        }
        
    }
}
