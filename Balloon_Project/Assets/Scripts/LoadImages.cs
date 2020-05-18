using System.Collections;
using System.Collections.Generic;
using System.Text;
using DigitalRuby.RainMaker;
using UnityEngine;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
    private Image _loadImage;
    private float time = 5.0f;
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        _loadImage = GameObject.Find("ScreenImages").GetComponent<Image>();
        var textureSet = Resources.Load<Sprite>(getImage());
        _loadImage.sprite = textureSet;
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        GameObject.Destroy(_loadImage);
        sound.GetComponent<RainScript>().enabled = true;
    }

    private string getImage()
    {
        string path = "Textures/LoadScreens/{0}";
        List<string> images = new List<string>()
        {
            "Screen1","Screen2","Screen3"
        };
        int num = UnityEngine.Random.Range(0, images.Count);
        return string.Format(path, images[num]);
    }
}