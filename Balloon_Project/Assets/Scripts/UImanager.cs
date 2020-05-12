using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(1);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
