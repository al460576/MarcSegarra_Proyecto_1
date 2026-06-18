using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    public void CambiarPantalla(string nombre)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }

    public void VolverAlJuego()
    {
        Time.timeScale = 1f;        
        SceneManager.UnloadSceneAsync("Opciones");
    }

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.volume = PlayerPrefs.GetFloat("Volumen", 1f);
        }
    }

    public void Salir()
    {
        Application.Quit();
    }
}