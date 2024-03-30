using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header(" Boton Single Game ")]
    [SerializeField] private SpriteRenderer singleGame;

    [Header(" Boton Local Game ")]
    [SerializeField] private SpriteRenderer localGame;

    [Header("Boton Options ")]
    [SerializeField] private SpriteRenderer optionsGame;

    [Header(" Variable de selección booleana del modo Single Game ")]
    [SerializeField] private bool estaSeleccionandoElModoSingle = false;

    [Header(" Variable de selección booleana del modo Local Game ")]
    [SerializeField] private bool estaSeleccionandoElModoLocal = false;

    [Header(" Variable de selección booleana del modo Options ")]
    [SerializeField] private bool estaSeleccionandoElModoOptions = false;

    [Header(" Variable de selección booleana para detección del inicio de la partida ")]
    [SerializeField] private bool partidaIniciada;

    [Header(" Tiempo en escena o in game ")]
    [SerializeField] private float tiempo;
    void Start()
    {
        
    }

    
    void Update()
    {
        eleccionOpciones();
        PresionarBotones();
    }

    void eleccionOpciones()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && estaSeleccionandoElModoSingle == false)
        {
            estaSeleccionandoElModoSingle = true;
            singleGame.color = Color.grey;
            localGame.color = Color.white;
            optionsGame.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && estaSeleccionandoElModoLocal == false)
        {
            estaSeleccionandoElModoLocal = true;
            singleGame.color = Color.white;
            localGame.color = Color.grey;
            optionsGame.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && estaSeleccionandoElModoOptions == false)
        {
            estaSeleccionandoElModoOptions = true;
            singleGame.color = Color.white;
            localGame.color = Color.white;
            optionsGame.color = Color.grey;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && estaSeleccionandoElModoOptions == true)
        {
            estaSeleccionandoElModoOptions = false;
            singleGame.color = Color.white;
            localGame.color = Color.grey;
            optionsGame.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && estaSeleccionandoElModoLocal == true)
        {
            estaSeleccionandoElModoLocal = false;
            singleGame.color = Color.grey;
            localGame.color = Color.white;
            optionsGame.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void PresionarBotones()
    {
        if (singleGame.color == Color.gray && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            partidaIniciada = true;

            if (partidaIniciada)
            {
                tiempo++;
            }
        }
        else if (localGame.color == Color.gray && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
            partidaIniciada = true;
        }
        else if (optionsGame.color == Color.gray && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(4);
        }
    }
}
