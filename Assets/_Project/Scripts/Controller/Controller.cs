using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public GameObject brick;

    public Transform[] spawnerBricks;

    public GameObject[] bricks;

    public List<GameObject> bricksList = new List<GameObject>();

    public GameObject ball;
    public GameObject panelGameOver;

    public float width;
    public float distance;

    public int lines;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI nameText;

    

    private void Initialization()
    {
        panelGameOver.SetActive(false);
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
            ShowHud();
        }
        else
        {
            ShowGameOver();
        }
    }

    private void ShowHud()
    {
        ScoreText.text = GameManager.instance.score.ToString();
        livesText.text = GameManager.instance.lives.ToString();
        nameText.text = GameManager.instance.namePlayer.ToString(); 
    }

    private void ShowGameOver()
    {
        
         ball.SetActive(false);
         panelGameOver.SetActive(true);
        
    }

    public void PlayGame()
    {
        GameManager.instance.lives = 3;
        GameManager.instance.isGameOver = false;
        panelGameOver.SetActive(false);
        SceneManager.LoadScene(1);
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.isGameOver = false;
    }

    private void NewLevel()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        spawnerBricks[0].position = new Vector3(-10.5f, 2.62f, 0);
        spawnerBricks[1].position = new Vector3(-10.5f, 2, 0);
        spawnerBricks[2].position = new Vector3(-10.5f, 1.4f, 0);
        spawnerBricks[3].position = new Vector3(-10.5f, 0.8f, 0);

        if (bricks.Length == 0)
        {
            ball.SetActive(false);

            for (int i = 0; i < bricksList.Count; i++)
            {
                bricksList[i].SetActive(true);
            }
        }
    }

    private void SpawnBricks()
    {
        for (int i = 0; i < lines; i++)
        {
            brick.GetComponent<SpriteRenderer>().color = Color.cyan;
            spawnerBricks[0].position = new Vector3(spawnerBricks[0].position.x + width + distance, spawnerBricks[0].position.y, spawnerBricks[0].position.z);
            Instantiate(brick, spawnerBricks[0].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 20;
        }

        for (int i = 0; i < lines; i++)
        {
            brick.GetComponent<SpriteRenderer>().color = Color.blue;
            spawnerBricks[1].position = new Vector3(spawnerBricks[1].position.x + width + distance, spawnerBricks[1].position.y, spawnerBricks[1].position.z);
            Instantiate(brick, spawnerBricks[1].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 15;
        }

        for (int x = 0; x < lines; x++)
        {
            brick.GetComponent<SpriteRenderer>().color = Color.magenta;
            spawnerBricks[2].position = new Vector3(spawnerBricks[2].position.x + width + distance, spawnerBricks[2].position.y, spawnerBricks[2].position.z);
            Instantiate(brick, spawnerBricks[2].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 10;
        }

        for (int d = 0; d < lines; d++)
        {
            brick.GetComponent<SpriteRenderer>().color = Color.green;
            spawnerBricks[3].position = new Vector3(spawnerBricks[3].position.x + width + distance, spawnerBricks[3].position.y, spawnerBricks[3].position.z);
            Instantiate(brick, spawnerBricks[3].position, Quaternion.identity);
            brick.GetComponent<Brick>().value = 5;
        }
    }
}
