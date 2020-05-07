using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTornado : MonoBehaviour
{
    private float T = 2.0f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tornado") Invoke("KillMe", T);
    }
    private void KillMe() {
        Destroy(gameObject);
    }
}
