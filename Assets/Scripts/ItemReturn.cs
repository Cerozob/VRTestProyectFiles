using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReturn : MonoBehaviour
{
    public Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            this.transform.position = initialPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
