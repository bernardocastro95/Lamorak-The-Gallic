using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    Vector2 direction = Vector2.one.normalized;
    Rigidbody2D r2d;
    public bool hit = false;
    [SerializeField]
    AudioSource aSource;
    [SerializeField]
    AudioSource aFail;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        //aSource = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (hit == false)
        {
            
            TrackMovement();
        }

        
        
    }

    void TrackMovement()
    {
        Vector2 trajectory = r2d.velocity;

        float angle = Mathf.Atan2(trajectory.y, trajectory.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Center")
        {
            hit = true;
            r2d.velocity = Vector2.zero;
            r2d.isKinematic = true;
            aFail.Stop();
            aSource.Play();
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(3);
            
        }
        else if(collision.gameObject.tag == "InvisibleWall")
        {
            hit = true;
            Destroy(this);
        }
        else
        {
            aSource.Stop();
            aFail.Play();
        }
    }

}
