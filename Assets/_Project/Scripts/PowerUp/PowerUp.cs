using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Range(0,10)]public float speed;

    public int powerIndex;

    public GameObject ball;

    public GameObject player;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUp;

    [SerializeField] private SpriteRenderer[] spriteRenderers;

    private SpriteRenderer image;

    private void Initialization()
    {
        image = GetComponent<SpriteRenderer>();
        SetPowerUpHandler();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void SetPowerUpHandler()
    {
        powerIndex = Random.Range(1, 5);

        switch (powerIndex)
        {
            case 1:
                image.sprite = spriteRenderers[3].sprite;
                break;
            case 2:
                image.sprite = spriteRenderers[2].sprite;
                break;
            case 3:
                image.sprite = spriteRenderers[4].sprite;
                break;
            case 4:
                image.sprite = spriteRenderers[0].sprite;
                break;
            case 5:
                image.sprite = spriteRenderers[1].sprite;
                break;
        }
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-9, 9), 7f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            audioSource.PlayOneShot(pickUp);
            PowerChoice(powerIndex);
            Disable(false);
        }

        if(collision.gameObject.TryGetComponent(out DeathZone deathZone))
        {
            Disable(false);
        }
    }

    private void PowerChoice( int power)
    {
        switch (power)
        {
            case 1: ball.GetComponent<Ball>().speed += 2f;
                
                break;
            case 2: player.transform.localScale += Vector3.right;
                
                break;
            case 3:
                
                for (int b = 0; b < 2; b++)
                {
                    Instantiate(ball, transform.position, Quaternion.identity);
                }
                break;
            case 4: ball.GetComponent<Ball>().speed -= 2f;
                
                break;
            case 5: player.transform.localScale -= Vector3.right;
                
                break;

        }

        print(power);
    }

    public void Disable( bool status)
    {
        image.enabled = status;
        transform.position = RandomPos();

        if (status)
        {
            SetPowerUpHandler();
        }
    }

    private void Movement()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }
}
