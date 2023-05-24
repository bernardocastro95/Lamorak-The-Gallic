using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Animator animator;
    public DragonFight df;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetBool("enemyClose", true);
            df.animator.SetBool("enemyAttack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("enemyClose", false);
        df.animator.SetBool("enemyAttack", false);
    }
}

