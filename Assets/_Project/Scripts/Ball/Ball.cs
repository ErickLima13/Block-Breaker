using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRb;

    [Range(0,30)]public float speed;

    public GameObject player;

    [SerializeField] private GameObject startGame;

    private void Initialization()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballRb.velocity = Vector2.up * speed;
    }

    private void Awake()
    {
        Initialization();
    }

    private float HitFactor(Vector2 ball,Vector2 player,float playerWidth)
    {
        return (ball.x - player.x) / playerWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.TryGetComponent(out Player player))
        {
            float x = HitFactor(transform.position,collision.transform.position,collision.collider.bounds.size.x);  
            Vector2 direction = new Vector2(x, 1).normalized;
            ballRb.velocity = direction * speed;
        }
        
    }

    private void OnDisable()
    {
        Vector3 pos = new Vector3(0.04f, -3.5f, 0);
        transform.position = pos;
        startGame.SetActive(true);
    }

    private void OnEnable()
    {
        Vector3 pos = new Vector3(player.transform.position.x,-3.5f, 0);
        transform.position = pos;
        ballRb.velocity = Vector2.up * speed;
        startGame.SetActive(false);
    }
}
