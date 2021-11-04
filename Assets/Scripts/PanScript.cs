using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanScript : MonoBehaviour
{
    public Text textPlayer;
    bool lechuga = false;
    bool tomate = false;
    bool cebolla = false;
    bool carne = false;
    public GameObject hamburguesa;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "lechuga")
        {
            lechuga = true;
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.name == "Tomato")
        {
            tomate = true;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.name == "Meat")
        {
            carne = true;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.name == "Onion")
        {
            cebolla = true;
            collision.gameObject.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(lechuga && tomate &&cebolla && carne )
        {
            textPlayer.text = "¡Y esta listo! Ya podemos disfrutar de nuestra hamburguesa. Agrega adiciones a gusto.";

            hamburguesa.SetActive(true);
            AgregoIngredientesHamburguesa();


        }
           
    }

    public void AgregoIngredientesHamburguesa()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "AgregoIngredientesHamburguesa", ""));
    }
}
