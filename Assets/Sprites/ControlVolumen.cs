using UnityEngine;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{
    public Slider sliderVolumen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderVolumen.value = PlayerPrefs.GetFloat("Volumen", 1f);  
        AplicarVolumen(sliderVolumen.value);

        sliderVolumen.onValueChanged.AddListener(AplicarVolumen);
        
    }
    void AplicarVolumen(float valor)
    {
        AudioSource[] fuentes = FindObjectsOfType<AudioSource>();
        foreach (AudioSource fuente in fuentes)
        {
            if (fuente != null)
                fuente.volume = valor;
        }
        PlayerPrefs.SetFloat("Volumen", valor);
    }

}
