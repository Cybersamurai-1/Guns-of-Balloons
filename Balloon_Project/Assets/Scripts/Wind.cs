using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private Transform T;
    private float Height;
    private float K = 0.005f;

    public float Speed;

    private float alpha = Mathf.PI / 2;
    private float alpha_small_delta = Mathf.PI / 8;
    private float alpha_big_delta = Mathf.PI / 6;

    private float Tmin = 0.25f;
    private float Tbig = 4f;

    private float Speedmin = 0.0f;
    public float Speedmax;
    private void Start()
    {
        T = gameObject.GetComponent<Transform>();
        Height = T.position.y; 
        Invoke("ChangeAlphaSmall", Tmin); 
        Invoke("ChangeAlphaBig", Tbig); 
    }
    private void ChangeAlphaSmall() {
        alpha += Random.Range(-alpha_small_delta, alpha_small_delta);
        Invoke("ChangeAlphaSmall", Tmin);
    }
    private void ChangeAlphaBig()
    {
        alpha += Random.Range(-alpha_big_delta, alpha_big_delta);
        Invoke("ChangeAlphaBig", Tbig);
    }
    private void Update()
    {
        float delta = (T.position.y - Height) * K;
        Speed += delta;
        if (Speed < Speedmin) { Speed = Speedmin; }
        else if (Speed > Speedmax) { Speed = Speedmax; }
        Height = T.position.y;
    }
    private void FixedUpdate()
    {
        T.position += new Vector3(Speed * Mathf.Cos(alpha), 0, Speed * Mathf.Sin(alpha));
    }
}
