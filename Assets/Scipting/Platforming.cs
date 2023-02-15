using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforming : MonoBehaviour
{
    private Vector2 moving;

    // a is called before the first frame update
    private void Awake()
    {
        moving = new Vector2(0,-0.05f);
    }

    private void FixedUpdate()
    {
        Vector2 tmp = transform.position;
        tmp += moving; 
        transform.position = tmp;

        if (tmp.y <= -12)
        {
            transform.position = new Vector2(Random.Range(-3.5f, 3.5f), 10);
        }
    }
}
