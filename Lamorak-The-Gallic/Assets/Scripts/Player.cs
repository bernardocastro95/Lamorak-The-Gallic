using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour


{

    Animator anim;
    public float speed = 0;
    Rigidbody2D r2d;
    float inputX, inputY;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    Transform groundCheckCollider;
    [SerializeField]
    LayerMask ground;
    bool isGrounded = false;
    const float checkGroundRadius = 0.2f;
    Vector3 respawn;
    public GameObject fallDetector;


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        respawn = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfOnGround();
        animator.SetFloat("GroundSpeed", Mathf.Abs(speed));

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Movement();

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

    void CheckIfOnGround()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, checkGroundRadius);
        if(colliders.Length > 0)
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
            
        }
    }

    void jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jumpButtonClicked", true);
        }
        else
        {
            anim.SetBool("jumpButtonClicked", false);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Begin")
        {
            transform.position = respawn;
        }
    }
}
