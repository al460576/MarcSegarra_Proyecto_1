using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual = 100f;
    public Image barraVida;

    void Start()
    {
        vidaActual = vidaMaxima;
        barraVida.fillAmount = 1f;
    }

    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;
        barraVida.fillAmount = vidaActual / vidaMaxima;
        Debug.Log("Vida jugador: " + vidaActual);
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