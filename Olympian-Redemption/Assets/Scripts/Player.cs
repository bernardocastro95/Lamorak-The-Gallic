using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

    
{
    public float speed = 10;
    bool jump = false;
    private Collider2D c2d;
    // Start is called before the first frame update
    void Start()
    {
        c2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        

        Vector3 move = new Vector3(speed * inputX, 0, 0);

        move *= Time.deltaTime;

        transform.Translate(move);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Debug.Log("Jumping");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate()
    {
        jump = false;
    }
}
