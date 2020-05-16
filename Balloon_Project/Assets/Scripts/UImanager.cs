using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit(); 
    }
    public void Settings()
    {

    }

    public void Continue()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
