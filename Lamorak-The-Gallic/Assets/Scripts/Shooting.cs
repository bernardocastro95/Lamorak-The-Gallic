using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator anim;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("mouseButtonClicked", true);
            Vector2 bowPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - bowPosition;
            transform.right = direction;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("mouseButtonClicked", false);
        }
        
    }
}
