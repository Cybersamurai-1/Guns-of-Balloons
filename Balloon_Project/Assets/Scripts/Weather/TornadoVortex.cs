using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoVortex : MonoBehaviour
{
    public float PullSpeed;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            GameObject PullOBJ = other.gameObject;

            Vector3 movement = this.transform.position - PullOBJ.transform.position;
            movement = PullSpeed * Time.deltaTime * movement.normalized;
            movement = transform.TransformDirection(movement);
            PullOBJ.gameObject.GetComponent<CharacterController>().Move(movement);
            // PullOBJ.transform.position = Vector3.MoveTowards(PullOBJ.transform.position, this.transform.position, PullSpeed * Time.deltaTime);
        }
    }
}
