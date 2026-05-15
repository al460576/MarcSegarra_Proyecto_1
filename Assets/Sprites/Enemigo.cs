using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float daño = 10f;
    public float tiempoEntreGolpes = 1.5f;
    public int puntosPorMuerte = 50;
    private float timerGolpe = 0f;

    void Update()
    {
        if (timerGolpe > 0)
            timerGolpe -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col) => IntentarGolpear(col);
    void OnTriggerStay2D(Collider2D col)  => IntentarGolpear(col);

    private void IntentarGolpear(Collider2D col)
    {
        if (col.CompareTag("Player") && timerGolpe <= 0)
        {
            VidaJugador vida = col.GetComponent<VidaJugador>();
            if (vida != null)
            {
                vida.RecibirDaño(daño);
                timerGolpe = tiempoEntreGolpes;
            }
        }
    }

    public void Morir()
    {
        Puntuacion.instancia.SumarPuntos(puntosPorMuerte);
        Destroy(gameObject);
    }
}