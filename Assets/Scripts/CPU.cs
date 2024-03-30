using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class CPU : MonoBehaviour
{
    [Header ("Velocidad de CPU")]
    [SerializeField, Range(0,10)] private float speed;

    [Header ("Posición de la pelota en la escena")]
    [SerializeField] private Transform ball;
    void Start()
    {
        
    }

    
    void Update()
    {
        CpuMovement();
    }

    void CpuMovement()
    {
        if (ball.transform.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (ball.transform.position.y < transform.position.y)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

   

}
