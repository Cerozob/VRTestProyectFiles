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
    public bool tomato = false;
    public bool lechuga = false;
    // Start is called before the first frame update
    void Start()
    {
 
    }
    public void CortoVerdurasTernera()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "CortoVerdurasTernera", ""));
    }

    public void CortoVerdurasHamburguesa()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "CortoVerdurasHamburguesa", ""));
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
        else if (lechuga && onion && tomato)
        {
            CortoVerdurasHamburguesa();
            yaCortoIngredientes = true;
            textPlayer.text = "Ahora, juntamos todos los ingredientes con el pan";
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
        else if (collision.gameObject.name == "Tomato")
        {
            chopParticles.Play();
            collision.gameObject.transform.Find("TomatoComplete").gameObject.SetActive(false);
            collision.gameObject.transform.Find("ChoppedTomatoes").gameObject.SetActive(true);
            tomato = true;
        }
        else if (collision.gameObject.name == "lechuga")
        {
            chopParticles.Play();
            collision.gameObject.transform.Find("LechugaCompleta").gameObject.SetActive(false);
            collision.gameObject.transform.Find("LechugaPicada").gameObject.SetActive(true);
            lechuga = true;
        }
    }
}
