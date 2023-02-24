using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforming : MonoBehaviour
{
    private Vector2 moving;
    public float downSpeed = -0.05f;
    private float screenEdge = 0.6f;
    private float usableHalfWidth;


    // a is called before the first frame update
    private void Awake()
    {
        moving = new Vector2(0, downSpeed);
        usableHalfWidth = (Screen.width / 200f) - screenEdge;

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
