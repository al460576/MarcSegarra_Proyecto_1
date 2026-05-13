using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;


public class ControlBrillo : MonoBehaviour
{
     public Slider sliderBrillo;
    public Light2D globalLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderBrillo.value = PlayerPrefs.GetFloat("Brillo", 1f);
        AplicarBrillo(sliderBrillo.value);
        sliderBrillo.onValueChanged.AddListener(AplicarBrillo);
    }

    void AplicarBrillo(float valor)
    {
        GameObject luzObj = GameObject.Find("Global Light 2D");
        if (luzObj != null)
        {
            UnityEngine.Rendering.Universal.Light2D globalLight = 
                luzObj.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            if (globalLight != null)
                globalLight.intensity = valor;
        }
        PlayerPrefs.SetFloat("Brillo", valor);
    }
}
