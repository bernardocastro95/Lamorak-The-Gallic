using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Animator animator;
    public DragonFight df;
    float distance;
    [SerializeField]
    private DuelUI ui;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(transform.position, df.transform.position);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attacked(); 
    }

    void Attacked()
    {
        if(distance < 2.6f)
        {
            animator.SetBool("hurt", true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetTrigger("enemyClose");
            df.animator.SetTrigger("enemyAttack");
            ui.playerLifeManager();
        }
    }
}

