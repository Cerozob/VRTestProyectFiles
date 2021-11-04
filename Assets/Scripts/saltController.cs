using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltController : MonoBehaviour
{
    private Rigidbody rgdBody;
    private ParticleSystem pSys;
    // Start is called before the first frame update
    void Start()
    {
        rgdBody = GetComponent<Rigidbody>();
        pSys = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rgdBody.IsSleeping())
        {
            pSys.Stop();
        }
        else
        {
            pSys.Play();
        }
    }
}
