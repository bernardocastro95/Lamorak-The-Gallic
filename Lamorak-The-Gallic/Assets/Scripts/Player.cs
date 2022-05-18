using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

    
{
    public float speed = 0;
    Rigidbody2D r2d;
    float inputX, inputY;
    

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("GroundSpeed", Mathf.Abs(speed));
        animator.SetBool("isJumping", false);

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Movement();
        BackToMainMenu();
        Jump();
        
    }

    void FixedUpdate()
    {
        r2d.velocity = new Vector2(speed * inputX, speed * inputY);
    }

    void Movement()
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

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            r2d.velocity = new Vector2(r2d.velocity.x, 10f);
        }
        
    }

    void BackToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }
    }
}
