using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using Unity.VisualScripting;

public class ControladorOptions : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float sliderVolumen;
    [SerializeField] private SpriteRenderer mute;
    [SerializeField] private SpriteRenderer sonidoActivo;
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value; 
    }

    public void ChangeSlider(float valor)
    {
        sliderVolumen = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderVolumen);
        AudioListener.volume = slider.value;

        //Imagen sonido mute
        if (sliderVolumen == 0)
        {
            mute.enabled = true;
            sonidoActivo.enabled = false;
        }
        else if (sliderVolumen > 0.1 || sliderVolumen < 0.3)
        {
           
            mute.enabled = false;
            sonidoActivo.enabled = true;
        }
        
    }

    void Update()
    {
        PressBack();
    }

    void PressBack()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }
    }
}
