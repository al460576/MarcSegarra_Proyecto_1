using UnityEngine;
using UnityEngine.SceneManagement;


public class Reinicio : MonoBehaviour
{
    public void Reiniciar(string nombre)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }

    public void VolverAlMenu(string nombre)
    {    
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }
}
