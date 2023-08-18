using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private GameObject df;
    private Rigidbody2D r2d;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        df = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = df.transform.position - transform.position;
        r2d.velocity = new Vector2(direction.x, - direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
