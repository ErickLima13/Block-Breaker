using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int value;

    public ParticleSystem explosionParticle;

    public AudioSource audioSource;
    public AudioClip damage;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ParticleSystem ps = explosionParticle.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule psmain = ps.main;
        psmain.startColor = spriteRenderer.color;

        explosionParticle.Play(true);
        audioSource.PlayOneShot(damage);
        collision.gameObject.GetComponent<SpriteRenderer>().color = spriteRenderer.color;
        Invoke(nameof(Explosion), 0.3f);
        
    }

    private void Explosion()
    {
        gameObject.SetActive(false);
        GameManager.instance.score += value;
    }
}
