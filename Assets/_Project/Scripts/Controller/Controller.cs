using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public GameObject brick;
    public GameObject ball;

    public PowerUp powerUp;

    public Transform[] spawnerBricks;

    public GameObject[] bricks;

    public List<GameObject> bricksList = new List<GameObject>();

    public float width;
    public float distance;

    public float powerUpTime;

    public int level = 1;

    public TextMeshProUGUI levelText;

    public int lines;

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
        if (!GameManager.instance.isGameOver)
        {
            NewLevel();
        }
    }

    private void NewLevel()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");

        levelText.text =  "Level : " + level.ToString();

        powerUpTime -= Time.deltaTime;

        if(powerUpTime <= 0)
        {
            powerUp.Disable(true);
            powerUpTime = 10f * level;
        }

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
