using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    public int Score = 0;
    
    public GameObject winText;
    public TMP_Text scoreText;

    Rigidbody2D rigidbody2d;

    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;

        //textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
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
            winText.SetActive(true);
            //Wait like 3 seconds
            //LoadScene("MainMenu");
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