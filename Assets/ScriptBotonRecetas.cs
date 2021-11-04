using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBotonRecetas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Touched()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "Touched", ""));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ColisionMano");
        if(other.gameObject.name == "RightHand Controller")
        {
            Touched();
        }
    }
}
