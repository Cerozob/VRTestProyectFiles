using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingPotController : MonoBehaviour
{
    public Text textPlayer;
    private bool oil;
    private bool choppedMushrooms;
    private bool choppedOnion;
    private bool choppedGarlic;
    private bool meatAdded;
    private bool salt;
    private bool chiliPowder;
    private bool soySauce;
    private bool yaAgregoIngredientes = false;
    private bool yaAgregoEspecias = false;
    public GameObject finishedDish;
    public GameObject mushroomsReady;
    public GameObject onionReady;
    public GameObject garlicReady;
    public GameObject meatReady;
    public GameObject ingredientesTernera;
    public GameObject ingredientesHamburguesa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (salt && chiliPowder && soySauce && !yaAgregoEspecias)
        {
            textPlayer.text = "¡Y esta listo! Ya podemos disfrutar de nuestra ternera picante. Agrega adiciones a gusto.";
            yaAgregoEspecias = true;
            finishedDish.SetActive(true);
            AgregoEspecias();
        }
        
        if (choppedMushrooms & choppedGarlic & choppedOnion && meatAdded && !yaAgregoIngredientes)
        {
            AgregoIngredientesTernera();
            yaAgregoIngredientes = true;
            textPlayer.text = "Ya casi terminamos! es momento de rozear sal, pimienta y agregar salsa soya";
        }
    }
    public void AgregoEspecias()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "AgregoEspecias", ""));
    }
    public void AgregoIngredientesTernera()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "AgregoIngredientesTernera", ""));
    }
    public void AgregoAceite()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "AgregoAceite", ""));
    }
    public void AgregoCarneHamburguesa()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "AgregoCarneHamburguesa", ""));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (ingredientesTernera.activeSelf == true)
        {
            if (oil)
            {
                if (collision.gameObject.name == "Mushrooms")
                {
                    if (collision.gameObject.transform.Find("ChoppedMushrooms").gameObject.activeSelf)
                    {
                        choppedMushrooms = true;
                        mushroomsReady.SetActive(true);
                        GameObject[] toDeactivateObjects = GameObject.FindGameObjectsWithTag("DeactivateMushroom");
                        foreach (GameObject toDeactivate in toDeactivateObjects)
                        {
                            toDeactivate.SetActive(false);
                        }
                    }
                }
                else if (collision.gameObject.name == "Onion")
                {
                    if (collision.gameObject.transform.Find("ChoppedOnion").gameObject.activeSelf)
                    {
                        choppedOnion = true;
                        onionReady.SetActive(true);
                        GameObject[] toDeactivateObjects = GameObject.FindGameObjectsWithTag("DeactivateOnion");
                        foreach (GameObject toDeactivate in toDeactivateObjects)
                        {
                            toDeactivate.SetActive(false);
                        }
                    }
                }
                else if (collision.gameObject.name == "Garlic")
                {
                    if (collision.gameObject.transform.Find("ChoppedGarlic").gameObject.activeSelf)
                    {
                        choppedGarlic = true;
                        garlicReady.SetActive(true);
                        GameObject[] toDeactivateObjects = GameObject.FindGameObjectsWithTag("DeactivateGarlic");
                        foreach (GameObject toDeactivate in toDeactivateObjects)
                        {
                            toDeactivate.SetActive(false);
                        }
                    }
                }
                else if (collision.gameObject.name == "Meat")
                {
                    meatAdded = true;
                    meatReady.SetActive(true);
                    GameObject[] toDeactivateObjects = GameObject.FindGameObjectsWithTag("DeactivateMeat");
                    foreach (GameObject toDeactivate in toDeactivateObjects)
                    {
                        toDeactivate.SetActive(false);
                    }

                }
            }
        }
        else if (ingredientesHamburguesa.activeSelf == true)
        {
            if(oil)
            {
                if(collision.gameObject.name == "carneHamburguesa")
                {
                    AgregoCarneHamburguesa();
                    meatReady.SetActive(true);
                    GameObject[] toDeactivateObjects = GameObject.FindGameObjectsWithTag("DeactivateMeat");
                    foreach (GameObject toDeactivate in toDeactivateObjects)
                    {
                        toDeactivate.SetActive(false);
                    }
                    textPlayer.text = "Excelente, a continuación vamos a cortar la cebolla, el tomate y la lechuga";
                }
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("PARTICLE DETECTED");
        Debug.Log(other.name);
        if (ingredientesTernera.activeSelf == true)
        {
            if (other.name == "Oil")
            {
                AgregoAceite();
                oil = true;
                textPlayer.text = "Muy bien, ahora que el aceite se esta calentando, podemos empezar a cortar los champiñones, el ajo y la cebolla e irlos agregando a la sarten";
            }
            else if (other.name == "Salt")
            {
                salt = true;

            }
            else if (other.name == "ChiliPowder")
            {
                chiliPowder = true;
            }
            else if (other.name == "Soy")
            {
                soySauce = true;
            }
        }
        else if(ingredientesHamburguesa.activeSelf == true)
        {
            if (other.name == "Oil")
            {
                AgregoAceite();
                oil = true;
                textPlayer.text = "Muy bien, ahora que el aceite se esta calentando, es hora de ingresar la carne en la sartén";
            }
        }
    }
}
