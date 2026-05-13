using UnityEngine;

public class Enemigo : MonoBehaviour
{ 
    public float daño = 10f;
    public float tiempoEntreGolpes = 1.5f;
    private float timerGolpe = 0f;

    void Update()
    {
        if (timerGolpe > 0)
        {
            timerGolpe -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && timerGolpe <= 0)
        {
            col.GetComponent<VidaJugador>().RecibirDaño(daño);
            timerGolpe = tiempoEntreGolpes;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && timerGolpe <= 0)
        {
            col.GetComponent<VidaJugador>().RecibirDaño(daño);
            timerGolpe = tiempoEntreGolpes;
        }
    }
}
