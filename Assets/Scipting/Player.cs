using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    public int Score = 0;
    public float uppies = 0.1f;
    public TMP_Text winText;
    public TMP_Text scoreText;

    Rigidbody2D rigidbody2d;

    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;

        // textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        RaycastHit2D up = Physics2D.Raycast(rigidbody2d.position * uppies, Vector2.up);
        RaycastHit2D down = Physics2D.Raycast(rigidbody2d.position * -uppies, Vector2.down);

        Vector2 upDebug = transform.TransformDirection(Vector2.up) * uppies;
        Vector2 downDebug = transform.TransformDirection(Vector2.down) * uppies;

        Debug.DrawRay(rigidbody2d.position, upDebug, Color.red);
        Debug.DrawRay(rigidbody2d.position, downDebug, Color.green);

        if (up.collider != null)
        {
            //disable collider
            GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("Help");
        }
        if (down.collider != null)
        {
            //enable collider
            GetComponent<CircleCollider2D>().enabled = true;
            Debug.Log("Uppies");
        }
    }

    private void FixedUpdate()
    {
        //if tap left move left, if tap right move right
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

        //if player gets too low go to menu
        if (transform.position.y < -15)
        {
            LoadScene("MainMenu");
            Score = 0;
        }

        if (Score >= 15)
        {
            //winText.enable = true;
            LoadScene("MainMenu");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //show score
        //textMeshPro.text = Score.ToString();
        Score++;
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}