using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSInput : MonoBehaviour
{
    public GameObject player;
    public bool WASD = false;
    public float CurrentMaxHeight = 100f; 
    public float MaxHeight = 200f;
    public float MinHeight = 50f;


    private float speed = 0;
    public float speedLeftRight = 50.0f;
    private CharacterController _charController;
    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float currentY = player.transform.position.y;
	    float speedUp = 0;
	    if (CurrentMaxHeight - currentY >= 0)
            speedUp = Convert.ToSingle(Math.Sqrt(CurrentMaxHeight - currentY));
        else            
            speedUp = Convert.ToSingle(-Math.Sqrt(-CurrentMaxHeight + currentY));

	    float deltaZ = 0;
        float deltaY = speedUp;
        if (WASD)
        {
	    deltaZ = Input.GetAxis("Vertical") * speedUp;
            float deltaX = Input.GetAxis("Horizontal") * speedLeftRight;
            transform.Rotate(0, deltaX * Time.deltaTime, 0);
	}


        if (Input.GetKey(KeyCode.Space))
        {
          
	        if (CurrentMaxHeight+1 <= MaxHeight)
                CurrentMaxHeight += 0.3f;
	    }
        if (Input.GetKey(KeyCode.LeftShift))
	    {
            if (CurrentMaxHeight-1 > MinHeight)
                CurrentMaxHeight -= 0.3f;
        }

        Vector3 movement = new Vector3(0, deltaY, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Math.Abs(speedUp));
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}