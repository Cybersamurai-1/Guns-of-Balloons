using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class statistic : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("temp_statistics.txt"))
        {
            string time, distance;
            using (var sr = new StreamReader("temp_statistics.txt"))
            {
                time = sr.ReadLine(); distance = sr.ReadLine();
            }
            File.Delete("temp_statistics.txt");
            text.text = $"Time: {time}  Distance={distance}";
        }
        else { text.text = ""; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
