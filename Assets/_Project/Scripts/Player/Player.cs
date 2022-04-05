using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 20)] public float speed;

    public GameObject ball;

   
    
    private void Initialization()
    {
        ball.SetActive(false);
    }

    private void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
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
            
        }
    }
}
