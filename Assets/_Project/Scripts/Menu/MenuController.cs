using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public TextMeshProUGUI textName;

    private void Initialization()
    {
        GameManager.instance.textName = textName;
    }


    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        GameManager.instance.PlayGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
