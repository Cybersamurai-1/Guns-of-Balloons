using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Water;

public class BallonSound : MonoBehaviour
{
    static AudioSource source;
 
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            source.enabled = true;

        }
        else
        {
            source.enabled = false;
        }
    }
}
