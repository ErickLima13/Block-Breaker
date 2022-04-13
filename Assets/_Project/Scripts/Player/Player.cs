using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 20)] public float speed;

    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject startGame;

    private void Initialization()
    {
        ball.SetActive(false);
    }

    private void Start()
    {
        Initialization();
    }

    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            Movement();
            NewBall();
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector2.right);
    }

    private void NewBall()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ball.SetActive(true);
            startGame.SetActive(false);
        }
    }
}
