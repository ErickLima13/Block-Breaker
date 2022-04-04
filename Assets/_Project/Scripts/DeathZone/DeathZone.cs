using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathZone : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip death;

    //colocar para ser trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            audioSource.PlayOneShot(death);
            GameManager.instance.lives--;
            collision.gameObject.SetActive(false);
        }
    }
}
