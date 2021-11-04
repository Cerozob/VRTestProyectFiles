using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text textoInstrucciones;
    public GameObject listaRecetas;
    public GameObject ingredientesTernera;
    public GameObject ingredientesHamburguesa;
    // Start is called before the first frame update
    void Start()
    {
        textoInstrucciones.text = "�Bienvenido! Aqu� podras aprender diferentes recetas";
    }
    public void DisplayRecetas()
    {
        textoInstrucciones.text = "Ahora selecciona la receta que te gustaria preparar";
        listaRecetas.gameObject.SetActive(true);
    }
    public void CargarRecetaTernera()
    {
        listaRecetas.gameObject.SetActive(false);
        ingredientesTernera.gameObject.SetActive(true);
        textoInstrucciones.text = "Vamos a cocinar ternera picante, lo primero es agregar aceite a la sarten";

    }

    public void CargarRecetaHamburguesa()
    {
        listaRecetas.gameObject.SetActive(false);
        ingredientesHamburguesa.gameObject.SetActive(true);
        textoInstrucciones.text = "Vamos a cocinar una hamburguesa, lo primero es agregar aceite a la sarten";
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
