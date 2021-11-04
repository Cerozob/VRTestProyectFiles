using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPhysics : MonoBehaviour
{
    public ParticleSystem oilDrip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            oilDrip.Play();
        }
        else
        {
            oilDrip.Stop();
        }
    }
}
