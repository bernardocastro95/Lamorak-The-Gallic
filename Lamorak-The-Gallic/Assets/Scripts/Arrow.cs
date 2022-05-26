using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float x;
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
        /*if(lateStart == false)
        {
            x = transform.localEulerAngles.z;
            lateStart = true;
        }
        transform.rotation = Quaternion.Euler(0, 0, x);*/

        float angle = Mathf.Atan2(r2d.velocity.y, r2d.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
