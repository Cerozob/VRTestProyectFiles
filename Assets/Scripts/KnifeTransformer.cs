using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeTransformer : MonoBehaviour
{
    public Text textPlayer;
    private bool yaCortoIngredientes = false;
    public ParticleSystem chopParticles;
    public bool mushrooms = false;
    public bool onion = false;
    public bool garlic = false;
    // Start is called before the first frame update
    void Start()
    {
 
    }
    public void CortoVerdurasTernera()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "CortoVerdurasTernera", ""));
    }
    // Update is called once per frame
    void Update()
    {
        if (mushrooms && onion && garlic && !yaCortoIngredientes)
        {
            CortoVerdurasTernera();
            yaCortoIngredientes = true;
            textPlayer.text = "Ahora, agregemos los ingredientes cortados a la sarten";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Garlic" )
        {
            chopParticles.Play();
            collision.gameObject.transform.Find("Garlic Complete").gameObject.SetActive(false);
            collision.gameObject.transform.Find("ChoppedGarlic").gameObject.SetActive(true);
            garlic = true;
        }
        else if(collision.gameObject.name == "Mushrooms")
        {
            chopParticles.Play();
            collision.gameObject.transform.Find("MushroomCollection").gameObject.SetActive(false);
            collision.gameObject.transform.Find("ChoppedMushrooms").gameObject.SetActive(true);
            mushrooms = true;
        }
        else if (collision.gameObject.name == "Onion")
        {
            chopParticles.Play();
            collision.gameObject.transform.Find("OnionComplete").gameObject.SetActive(false);
            collision.gameObject.transform.Find("ChoppedOnion").gameObject.SetActive(true);
            onion = true;
        }
    }
}
