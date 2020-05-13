using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    [HideInInspector]
    public float T_start;
    private float PlayedTime = 0.0f;
    private Vector3 Position;
    private Transform T;
    private float TraveledDistance = 0.0f;

    public Text DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        T = gameObject.GetComponent<Transform>(); Position = T.position; T_start = Time.time;
    }

    public Dictionary<string, string> GetStatistics()
    {
        var d = new Dictionary<string, string>();
        d.Add("RlayedTime", Math.Round(PlayedTime, 2).ToString());
        d.Add("Distance traveled", Math.Round(TraveledDistance, 2).ToString());
        return d;
    }

    // Update is called once per frame
    void Update()
    {
        PlayedTime += Time.deltaTime;
        TraveledDistance += (T.position - Position).magnitude;

        DisplayText.text = $"Played time: {Math.Round(PlayedTime, 2)}  Distance traveled: {Math.Round(TraveledDistance, 2)}";

        Position = T.position;
    }
}
