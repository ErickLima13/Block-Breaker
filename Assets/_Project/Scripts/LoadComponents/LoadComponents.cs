using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadComponents : MonoBehaviour
{
    private void Initialization()
    {
        Invoke(nameof(ComponentsLoad), 0.01f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    public void ComponentsLoad()
    {
        SceneManager.LoadScene("Menu");
    }
}
