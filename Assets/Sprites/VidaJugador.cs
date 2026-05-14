using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual = 100f;
    public Slider barraVida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMaxima;
        barraVida.maxValue = vidaMaxima;
        barraVida.value = vidaActual;
    }
    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;
        barraVida.value = vidaActual;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        SceneManager.LoadScene("GameOver");
    }
}
