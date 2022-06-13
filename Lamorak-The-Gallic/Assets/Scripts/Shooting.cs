using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator anim;
    public Vector2 aim;
    public float force;
    public GameObject arrow;
    public int launch;
    public Transform shotPoint;
    public Transform target;
    [SerializeField]
    private UI ui;
    [SerializeField]
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {

        ui.middleText.text = "Aim with your mouse and click to shoot. You must hit the target on it's bullseye at least once to win with 3 shots.";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        aim = mousePos - playerPos;


        if (gm.gameRunning)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                ui.middleText.text = "";
                anim.SetBool("mouseButtonClicked", true);
                aimingBow();

            }
            else if (Input.GetMouseButtonUp(0))
            {
                ui.middleText.text = "";
                anim.SetBool("mouseButtonClicked", false);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                shootingArrow();
                ui.lifeUiManager();
                

            }
            
        }
    }
    void aimingBow()
    {
        transform.right = aim;
    }

    void shootingArrow()
    {
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 dir = (Vector2)((mousePos - transform.position));
        GameObject arrowShot = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        arrowShot.GetComponent<Rigidbody2D>().velocity = dir * force;
        
    }
}
