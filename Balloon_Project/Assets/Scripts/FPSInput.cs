using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 2.0f;
    public float speedLeftRight = 50.0f;
    public bool WASD = false;
    private CharacterController _charController;
    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
	float deltaZ = 0;
        float deltaY = 0;
        if (WASD)
        {
	    deltaZ = Input.GetAxis("Vertical") * speed;
            float deltaX = Input.GetAxis("Horizontal") * speedLeftRight;
            transform.Rotate(0, deltaX * Time.deltaTime, 0);
	}


        if (Input.GetKey(KeyCode.Space))
            deltaY += speed;
        if (Input.GetKey(KeyCode.LeftShift))
            deltaY -= speed;

        Vector3 movement = new Vector3(0, deltaY, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
