using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Velocidad de los jugadores")]
    [SerializeField, Range(0,10)] private float speed;

    [Header("Player 1")]
    [SerializeField] private GameObject player1;

    [Header("Player 2")]
    [SerializeField] private GameObject player2;
    void Start()
    {
        
    }

    void Update()
    {
        MovementPlayerOne();
        MovementPlayerTwo();
    }

    public void MovementPlayerOne()
    {
        float ver = Input.GetAxis("Vertical");
        player1.transform.Translate(new Vector2(0f, ver) * speed * Time.deltaTime);
    }

    public void MovementPlayerTwo()
    {
        float verTwo = Input.GetAxis("Vertical1");
        player2.transform.Translate(new Vector2(0f, verTwo) * speed * Time.deltaTime);
    }

}
