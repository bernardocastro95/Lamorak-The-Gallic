﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator anim;
    public Vector2 aim;
    public float force;
    public GameObject circlePrefab;
    public GameObject[] circles;
    public int numberOfCircles;
    // Start is called before the first frame update
    void Start()
    {
        circles = new GameObject[numberOfCircles];

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        aim = mousePos - playerPos;

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("mouseButtonClicked", true);
            for (int i = 0; i < numberOfCircles; i++)
            {
                circles[i] = Instantiate(circlePrefab, transform.position, Quaternion.identity);   
                circles[i].transform.position = pointingThePosition(i * 0.1f);
                aimingBow();
            }
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);          

        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("mouseButtonClicked", false);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            shootingArrow();
            for(int i = 0; i < numberOfCircles; i++)
            {
                Destroy(circles[i]);
            }
            
        }
    }


    void aimingBow()
    {
        transform.right = aim;
    }

    void shootingArrow()
    {
        Debug.Log("Shooting Arrow");
    }

    Vector2 pointingThePosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (aim.normalized * force * t) + .5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
}
