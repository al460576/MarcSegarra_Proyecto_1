using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    public static Puntuacion instancia;

    public TextMeshProUGUI textoPuntuacion;
    public int puntos = 0;
    private float timer = 0f;

    void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            puntos += 10;
            timer = 0f;
            ActualizarTexto();
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoPuntuacion.text = "Puntuación: " + puntos;
    }
}