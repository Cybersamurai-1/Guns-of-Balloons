using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollidesWith : MonoBehaviour
{
    private float T_limit = 3.0f;
    private Statistics S;

    private float T_success = 1.0f;
    public string scene_successful = "Menu";

    private float T_failure = 0.5f;
    public string scene_failure = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        S = gameObject.GetComponent<Statistics>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (TooEarly()) { return; }
        if (other.gameObject.tag == "ExitPointSuccess") { Invoke("Success", T_success); return; }
        if (other.gameObject.tag == "ExitPointFailure") { Invoke("Failure", T_failure); return; }
    }
    private bool TooEarly()
    {
        return (Time.timeSinceLevelLoad <= T_limit);
    }
    private void Success()
    {
        BeforeExit();
        Exit(scene_successful);
    }
    private void Failure()
    {
        BeforeExit();
        Exit(scene_failure);
    }
    private void BeforeExit()
    {
        string file_name = $"{Directory.GetCurrentDirectory()}\\temp_statistics.txt";
        using (var f = File.Create(file_name))
        {
            using (var sw = new StreamWriter(f))
            {
                var d = S.GetStatistics();
                sw.WriteLine(d["RlayedTime"]);
                sw.WriteLine(d["Distance traveled"]);
            }

        }
    }
    private void Exit(string sceme_name)
    {
        SceneManager.LoadScene(sceme_name);
    }
}
