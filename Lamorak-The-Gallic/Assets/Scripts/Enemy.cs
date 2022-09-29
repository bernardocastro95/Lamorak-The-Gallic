using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D r2d;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Transform[] waypoints;
    private int waypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();     
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        pos.z = -9;
        transform.position = pos;
        if (gm.paused == true || gm.isGameOver == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        movePattern();
    }

    void movePattern()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            animator.SetFloat("speed", Mathf.Abs(speed));
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        }
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetBool("enemyClose", true);
        }
        else
        {
            animator.SetBool("enemyClose", false);
        }
    }
}
