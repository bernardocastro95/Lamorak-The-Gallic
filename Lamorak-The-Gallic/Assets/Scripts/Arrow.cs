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
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hit == false)
        {
            //r2d.AddRelativeForce(direction * magnitude, ForceMode2D.Force);
            TrackMovement();
        }

        
        
    }

    void TrackMovement()
    {
        Vector2 trajectory = r2d.velocity;

        float angle = Mathf.Atan2(trajectory.y, trajectory.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Target" || collision.gameObject.tag == "Ground")
        {
            hit = true;
            r2d.velocity = Vector2.zero;
            r2d.isKinematic = true;
        }
        else if(collision.gameObject.tag == "InvisibleWall")
        {
            hit = true;
            Destroy(this);
        }
    }
}
