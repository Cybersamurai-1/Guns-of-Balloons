using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_game : MonoBehaviour
{
    public GameObject knot;
    public GameObject player;
    

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
	{
            player.GetComponent<Wind>().enabled = true;
	    player.GetComponent<FPSInput>().enabled = true;
            Destroy(knot);
	    Destroy(this);
	}
    }
}
