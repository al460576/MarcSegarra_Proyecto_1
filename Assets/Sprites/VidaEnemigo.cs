using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidaMaxima = 50f;
    private float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;
        Debug.Log("Vida enemigo " + gameObject.name + ": " + vidaActual);
        if (vidaActual <= 0)
        {
            GetComponent<Enemigo>().Morir();
        }
    }
}