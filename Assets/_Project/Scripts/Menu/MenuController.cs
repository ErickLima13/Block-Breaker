using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI textName;

    [SerializeField] private AudioMixer masterMixer;


    private void Initialization()
    {
        GameManager.instance.textName = textName;

       
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

  
    

    public void PlayGame()
    {
        GameManager.instance.PlayGame();
        GameManager.instance.gameOver = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetVolumeBGM(float volume)
    {
        masterMixer.SetFloat("BGM", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        masterMixer.SetFloat("SFX", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
