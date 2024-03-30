using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaCargaAceptar : MonoBehaviour
{
    [Header("Boton Press W ")]
    [SerializeField] private SpriteRenderer pressW;

    [Header(" Detección si el jugador1 esta listo ")]
    [SerializeField] private bool estaListoJugador1 = false;

    [Header(" Boton Press flecha arriba ")]
    [SerializeField] private SpriteRenderer pressFlechaArriba;

    [Header(" Detección si el jugador2 esta listo ")]
    [SerializeField] private bool estaListoJugador2 = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        PulsacionesJugadores();
        EnvioOtraEscena();
        PressBack();
    }

    void PulsacionesJugadores()
    {
        if (Input.GetKeyDown(KeyCode.W) && estaListoJugador1 == false)
        {
            estaListoJugador1 = true;
            pressW.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.S) && estaListoJugador1 == true)
        {
            estaListoJugador1 = false;
            pressW.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && estaListoJugador2 == false)
        {
            estaListoJugador2 = true;
            pressFlechaArriba.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && estaListoJugador2 == true)
        {
            estaListoJugador2 = false;
            pressFlechaArriba.color = Color.white;
        }
    }

    void EnvioOtraEscena()
    {
        if (pressW.color == Color.green && pressFlechaArriba.color == Color.green)
        {
            pressW.color = Color.green;
            pressFlechaArriba.color = Color.green;
            Invoke("Escena", 0.1f);
        }
    }

    void PressBack()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }
    }

    void Escena()
    {
        SceneManager.LoadScene(3);
    }
}
