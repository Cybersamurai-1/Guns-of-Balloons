using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public float PlayedTime = 0.0f;
    private Vector3 Position;
    private Transform T;
    public float TraveledDistance = 0.0f;

    public Text time;
    public Text distance;

    // Start is called before the first frame update
    void Start()
    {
        T = gameObject.GetComponent<Transform>(); Position = T.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayedTime += Time.deltaTime;
        TraveledDistance += (T.position - Position).magnitude;

        time.text = $"Played time: {Math.Round(PlayedTime,2)}";
        distance.text = $"Distance traveled: {Math.Round(TraveledDistance, 2)}";

        Position = T.position;
    }
}
