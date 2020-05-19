using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPreview : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 12f;
    private int scene_id = 1;
    void Start()
    {
        StartCoroutine(LoadIntro());
    }

    IEnumerator LoadIntro()
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(scene_id);
    }
}
