using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    Rigidbody2D rigidBody;
    int Score = 0;
    public GameObject winText;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            LoadScene("MainMenu");
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
