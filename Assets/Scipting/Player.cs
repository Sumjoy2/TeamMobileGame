using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    Rigidbody2D rigidbody2d;
    public int Score = 0;
    public GameObject winText;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            LoadScene("MainMenu");
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0)
            {
                transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            if (mousePos.x > 0)
            {
                transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Score++;
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
