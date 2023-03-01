using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforming : MonoBehaviour
{
    private Vector2 moving;
    public float downSpeed = -0.05f;
    private float screenEdge = 0.6f;
    public float uppies = 0.1f;
    public float invTimer = 0.0f;
    private float timerCollider;
    private float usableHalfWidth;


    // awake is called before the first frame update
    private void Awake()
    {
        moving = new Vector2(0, downSpeed);
        usableHalfWidth = (Screen.width / 200f) - screenEdge;

        GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        /*********************
         * New plan
         * timer that after up raycast hits something wait .5 to 1 sec then re enable Collider
         * ******************/

        RaycastHit2D up = Physics2D.Raycast(transform.position * uppies, Vector2.up);

        Vector2 upDebug = transform.TransformDirection(Vector2.up) * uppies;

        Debug.DrawRay(transform.position, upDebug, Color.red);

        if (up.collider != null)
        {
            //disable collider
            GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("Help" + gameObject.name + "invTimer = " + invTimer); //This Made Work Slightly? WHY??
            timerCollider = invTimer;
        }

        if (timerCollider > 0)
        {
            timerCollider -= Time.deltaTime;
        }
        else
        {
            //enable collider
            GetComponent<BoxCollider2D>().enabled = false;
            //Debug.Log("Uppies");
            timerCollider = -1.0f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 tmp = transform.position;
        tmp += moving; 
        transform.position = tmp;

        if (tmp.y <= -12)
        {
            transform.position = new Vector2(Random.Range(-usableHalfWidth, usableHalfWidth), 10);
        }
    }
}
