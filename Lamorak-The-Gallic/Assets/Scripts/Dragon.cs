using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    public Animator animator;
    public DragonFight df;
    public float distance;
    public FinalDuelUI fui;
    public bool enemyClose, hurt;
    public GameObject fireball;
    public Transform shotPoint;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, df.transform.position);
        animator.SetBool("enemyClose", false);
        Attack();
        Attacked();
        
    }

    void Attack()
    {
        if (distance < 2.5f)
        {
            enemyClose = true;
            animator.SetBool("enemyClose", true);
            //GameObject fireball = Instantiate(fireball, shotPoint, shotPoint);

        }
        else
        {
            enemyClose = false;
            animator.SetBool("enemyClose", false);
        }
    }
    void Attacked()
    {
        if (distance < 3f && df.isClicked == true)
        {
            hurt = true;
            animator.SetBool("hurt", true);
        }
       else
        {
            hurt = false;
            animator.SetBool("hurt", false);
        }
    }
}
