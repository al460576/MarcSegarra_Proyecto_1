using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambiarPantalla(string nombre){
        SceneManager.LoadScene(nombre);
    }
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.volume = PlayerPrefs.GetFloat("Volumen", 1f);
        }
    }

    public void Salir(){
        Application.Quit();
    }
}
