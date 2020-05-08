using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogs : MonoBehaviour
{
    public ParticleSystem [] particles = new ParticleSystem[8];
    bool first = true;
    int check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            check = Random.Range(1, 3);
            print(check);
            first = false;
        }
        if (check == 1)
        {
            particles[0].Emit(1);
            particles[1].Emit(1);
            particles[2].Emit(1);
            particles[3].Emit(1);
            particles[4].Emit(1);
            particles[5].Emit(1);
            particles[6].Emit(1);
            particles[7].Emit(1);

        }
    }
}
