using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlarTiempo : Ball
{
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private float tiempoActual;
    [SerializeField] private bool tiempoActivado = false;
    [SerializeField] private float increment = 10f;
    [SerializeField] private bool isPaused = false;
    [SerializeField] private SpriteRenderer marcoMenu;
    [SerializeField] private SpriteRenderer Exit;
    [SerializeField] private SpriteRenderer Options;
    [SerializeField] private SpriteRenderer fondoDesenfocado;
    [SerializeField] private bool estaSeleccionandoElModoExit = true;
    [SerializeField] private bool estaSeleccionandoElModoOptions = false;


    void Start()
    {
        ActivarTemporizador();
    }


    void Update()
    {
        if (tiempoActivado)
        {
            CambiarTemporizador();
        }
        TogglePause();
        OpcionesMenuPausa();
    }


    void TogglePause()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            isPaused = true;
            fondoDesenfocado.enabled = true;
            marcoMenu.enabled = true;
            Exit.enabled = true;
            Options.enabled = true;   
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            isPaused = !isPaused;
            fondoDesenfocado.enabled = false;
            marcoMenu.enabled = false;
            Exit.enabled = false;
            Options.enabled = false;
        }
    }


    void OpcionesMenuPausa()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && estaSeleccionandoElModoExit == true)
        {
            estaSeleccionandoElModoOptions = true;
            Exit.color = Color.white;
            Options.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && estaSeleccionandoElModoOptions == true)
        {
            estaSeleccionandoElModoOptions = false;
            Exit.color = Color.red;
            Options.color = Color.white;
        }
        else if (Exit.color == Color.red && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
        else if (Options.color == Color.red && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(4);
        }
    }
    private void CambiarTemporizador()
    {
        tiempoActual += Time.deltaTime;

        if (tiempoActual >= 10)
        {
            Debug.Log("Aumento de velocidad de la pelota");
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
