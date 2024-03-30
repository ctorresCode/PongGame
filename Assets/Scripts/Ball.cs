using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [Header ("Velocidad de la pelota")]
    [SerializeField, Range(1, 100)] protected float speed = 7;

    [Header("Referencia el rigidbody de la pelota")]
    [SerializeField] protected Rigidbody2D ball;

    [Header("Respawn de la pelota")]
    [SerializeField] private Transform respawn;

    [Header("Puntuacion jugador 1")]
    [SerializeField] private Text pointPlayerOneText;

    [Header("Puntuacion jugador 2")]
    [SerializeField] private Text pointPlayerTwoText;

    [Header("Entero de incremento puntuacion 1")]
    [SerializeField] private int pointIncrementPlayerOne;

    [Header("Entero de incremento puntuacion 2")]
    [SerializeField] private int pointIncrementPlayerTwo;

    [Header("Letrero de victoria jugador 1")]
    [SerializeField] private SpriteRenderer winOne;

    [Header("Letrero de victoria jugador 2")]
    [SerializeField] private SpriteRenderer winTwo;

    [Header("Controlador de las escenas")]
    [SerializeField] private SceneManager sceneManager;

    [Header("El jugador 1")]
    [SerializeField] private GameObject player1;

    [Header("El jugador 2")]
    [SerializeField] private GameObject player2;

    [Header("Quien emite los sonidos")]
    [SerializeField] private AudioSource WinnerSources;

    [Header("El sonido Winner cuando gane uno de los dos jugadores")]
    [SerializeField] private AudioClip winner;

    [Header("Controlador animaciones contador")]
    [SerializeField] private Animation animacion;

    [Header("Menu jugador gano")]
    [SerializeField] private SpriteRenderer menuFondo;
    [SerializeField] private SpriteRenderer rematch;
    [SerializeField] private SpriteRenderer exitMenu;
    [SerializeField] private SpriteRenderer fondoBorroso;

    [Header("Variables de control de seleccion en menu victoria")]
    [SerializeField] private bool estaSeleccionandoRematch = true;
    [SerializeField] private bool estaSeleccionandoExitMenu = false;
    void Start()
    {
        Reset();
        ball.velocity = Vector2.zero;
        StartCoroutine(tiempoSalidaPelota());
    }
    void LaunchBall()
    {
        float x = Random.Range(0, 2) * Time.deltaTime == 0 ? 1 : -1;
        float y = Random.Range(0, 2) * Time.deltaTime == 0 ? 1 : -1;
        ball.velocity = new Vector2(speed * x, speed * y);
    }

    private void Reset()
    {
        transform.position = respawn.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collision2"))
        {
            pointIncrementPlayerOne++;
            pointPlayerOneText.text = pointIncrementPlayerOne.ToString();
            transform.position = respawn.transform.position;
            Reset();
        }
        else if (collision.gameObject.CompareTag("Collision1"))
        {
            pointIncrementPlayerTwo++;
            pointPlayerTwoText.text = pointIncrementPlayerTwo.ToString();
            transform.position = respawn.transform.position;
            Reset();
        }
        else if (collision.gameObject.CompareTag("CollisionLateral1") || collision.gameObject.CompareTag("CollisionLateral2"))
        {
            player1.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else if (collision.gameObject.CompareTag("CollisionLateral3") || collision.gameObject.CompareTag("CollisionLateral4"))
        {
            player2.transform.position = new Vector2(transform.position.x, transform.position.y);
        }

        if (pointIncrementPlayerOne == 5)
        {
            speed = 0;
            winOne.enabled = true;
            WinnerSources.PlayOneShot(winner);
            ball.velocity = Vector2.zero;
            Invoke("llamadaMenu", 1f);
        }
        else if (pointIncrementPlayerTwo == 5)
        {
            winTwo.enabled = true;
            WinnerSources.PlayOneShot(winner);
            ball.velocity = Vector2.zero;
            Invoke("llamadaMenu", 1f);
        }
    }

    IEnumerator tiempoSalidaPelota()
    {
        yield return new WaitForSeconds(2.5f);
        LaunchBall();
    }


    void llamadaMenu()
    {
        SceneManager.LoadScene(0);

    }
}
