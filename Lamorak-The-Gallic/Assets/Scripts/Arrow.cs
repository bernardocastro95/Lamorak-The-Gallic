using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float x;
    Vector2 direction = Vector2.one.normalized;
    float magnitude = .05f;
    public bool lateStart;
    Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //float angle = Mathf.Atan2(r2d.velocity.y, r2d.velocity.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        r2d.AddRelativeForce(direction * magnitude, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Circle")
        {
            x -= 5;
        }
        else if(collision.gameObject.tag == "Ground")
        {
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
