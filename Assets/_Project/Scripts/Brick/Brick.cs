using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int value;

    public ParticleSystem explosionParticle;

    public AudioSource audioSource;
    public AudioClip damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosionParticle.Play(true);
        audioSource.PlayOneShot(damage);
        Invoke(nameof(Explosion), 0.3f);
        
    }

    private void Explosion()
    {
        gameObject.SetActive(false);
        GameManager.instance.score += value;
    }
}
