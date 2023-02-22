using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    Rigidbody2D rigidbody2d;
    public int Score = 0;
    public GameObject winText;
   // public GameObject scoreText;

    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;

       // textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

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
        }

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //show score
        //textMeshPro.text = Score.ToString();
        //  if (other.tag == "Platform")
        Score++;
        /*{
            if (rigidbody2d.velocity.y < 0)
            {
                other.enabled = !other.enabled;
                
            }
            else
            {
                other.enabled = !other.enabled;
            }
        }*/
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
