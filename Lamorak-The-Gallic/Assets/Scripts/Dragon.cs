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
    public float fireshotForce;
    private float timer;
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
        timer += Time.deltaTime;
        Attack();
        Attacked();

    }

    void Attack()
    {
        if (timer > 5)
        {
            timer = 0;
            enemyClose = true;
            animator.SetBool("enemyClose", true);
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            


        }
        else
        {
            enemyClose = false;
            animator.SetBool("enemyClose", false);
        }
    }
    void Attacked()
    {
        if (df.isClicked == true)
        {
            hurt = true;
            animator.SetBool("hurt", true);
            fui.enemyLifeManager();
        }
       else
        {
            hurt = false;
            animator.SetBool("hurt", false);
        }
    }

    


}
