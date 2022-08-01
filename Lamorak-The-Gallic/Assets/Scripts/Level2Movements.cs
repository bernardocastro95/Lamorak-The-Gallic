using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Movements : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rbody;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping();
        }
        else
        {
            animator.SetBool("jumpButtonClicked", false);
        }

      

    }

    /*void FixedUpdate()
    {
        rbody.velocity = new Vector2(speed * inputX, speed * inputY);
    }*/
    void Jumping()
    {

        rbody.velocity = Vector2.up * jumpForce;
        animator.SetBool("jumpButtonClicked", true);

    }

    /* void MoveLeft()
     {
          speed += 10;
          gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);  
     }
     void MoveRight()
     {
         speed += 10;
         gameObject.transform.localScale = new Vector3(-.5f, .5f, .5f);
     }
     void StopMovement()
     {
         speed -= 10;
     }*/
}
