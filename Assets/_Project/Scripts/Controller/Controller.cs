using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private GameObject ball;

    [SerializeField] private PowerUp powerUp;

    [SerializeField] private Transform[] spawnerBricks;

    [SerializeField] private GameObject[] bricks;

    [SerializeField] private List<GameObject> bricksList = new List<GameObject>();

    [SerializeField] private float width;
    [SerializeField] private float distance;

    [SerializeField] private float powerUpTime;

    [SerializeField] private int level = 1;

    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private int lines;

    private void Initialization()
    {
        powerUpTime = 10f;
        distance = 0.10f;
        width = brick.transform.localScale.x;
        SpawnBricks();
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        bricksList.AddRange(bricks);
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            NewLevel();
            PoweUpSpawn();
        }
    }

    private void NewLevel()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");

        levelText.text =  "Level : " + level.ToString();

        if (bricks.Length == 0)
        {
            ball.SetActive(false);
            ball.GetComponent<Ball>().speed += 0.5f;
            level++;

            for (int i = 0; i < bricksList.Count; i++)
            {
                bricksList[i].transform.position = RandomSpawnPos();
                bricksList[i].SetActive(true);
            }
        }
    }

    private void PoweUpSpawn()
    {
        powerUpTime -= Time.deltaTime;

        if (powerUpTime <= 0)
        {
            powerUp.Disable(true);
            powerUpTime = 10f * level;
        }
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-9, 9) + distance * width , Random.Range(0, 5));
    }

    private void SpawnBricks()
    {
        for (int i = 0; i < lines; i++)
        {
            brick.GetComponent<SpriteRenderer>().color = Color.cyan;
            spawnerBricks[0].position = new Vector3(spawnerBricks[0].position.x + width + distance, spawnerBricks[0].position.y, spawnerBricks[0].position.z);
            Instantiate(brick, spawnerBricks[0].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 20;

            brick.GetComponent<SpriteRenderer>().color = Color.blue;
            spawnerBricks[1].position = new Vector3(spawnerBricks[1].position.x + width + distance, spawnerBricks[1].position.y, spawnerBricks[1].position.z);
            Instantiate(brick, spawnerBricks[1].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 15;

            brick.GetComponent<SpriteRenderer>().color = Color.magenta;
            spawnerBricks[2].position = new Vector3(spawnerBricks[2].position.x + width + distance, spawnerBricks[2].position.y, spawnerBricks[2].position.z);
            Instantiate(brick, spawnerBricks[2].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 10;

            brick.GetComponent<SpriteRenderer>().color = Color.green;
            spawnerBricks[3].position = new Vector3(spawnerBricks[3].position.x + width + distance, spawnerBricks[3].position.y, spawnerBricks[3].position.z);
            Instantiate(brick, spawnerBricks[3].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 5;

        }
    }
}
