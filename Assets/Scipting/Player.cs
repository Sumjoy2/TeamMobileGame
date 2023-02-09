using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    Rigidbody2D rb;
    int Score = 0;
    public GameObject winText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


}
