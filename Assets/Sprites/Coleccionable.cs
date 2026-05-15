using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int puntos = 25;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Puntuacion.instancia.SumarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}