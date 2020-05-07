using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private Transform T;
    private CharacterController CC;
    private Vector3 movement;
    private float Height;
    public float K = 0.1f;

    public float Speed = 1.0f;

    private float alpha = Mathf.PI / 2;
    private float alpha_small_delta = Mathf.PI / 8;
    private float alpha_big_delta = Mathf.PI / 6;
    private float alpha_rotate = 0.0f;
    private float alpha_rotate_delta = Mathf.PI / 18;
    private float max_alpha_rotate = 2 * (Mathf.PI / 18);

    private float Tmin = 5.0f;
    private float Tbig = 10.0f;

    private float Speedmin = 0.0f;
    public float Speedmax = 8.0f;
    private void Start()
    {
        T = gameObject.GetComponent<Transform>(); CC = gameObject.GetComponent<CharacterController>();
        Height = T.position.y; 
        Invoke("ChangeAlphaSmall", Tmin); Invoke("ChangeAlphaBig", Tbig);
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
    private void UpdateRotation() {
        float cur_alpha = alpha_rotate;
        cur_alpha += Random.Range(-alpha_rotate_delta, alpha_rotate_delta);
        if (cur_alpha > max_alpha_rotate) { cur_alpha = max_alpha_rotate; }
        else if (-cur_alpha < -max_alpha_rotate) { cur_alpha = -max_alpha_rotate; }
        transform.RotateAround(transform.position, transform.forward, cur_alpha - alpha_rotate);
        alpha_rotate = cur_alpha;
    }
    private void UpdateHorizontalWind() {
        Speed += (T.position.y - Height) * K; 
        Height = T.position.y;
        if (Speed < Speedmin) { Speed = Speedmin; }
        else if (Speed > Speedmax) { Speed = Speedmax; }
    }
    private void Update()
    {
        UpdateHorizontalWind();
        UpdateRotation();
    }
    private void FixedUpdate()
    {
        movement = new Vector3(Speed * Mathf.Cos(alpha), 0, Speed * Mathf.Sin(alpha));
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        CC.Move(movement);
    }
}
