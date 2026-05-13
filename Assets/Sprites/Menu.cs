using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambiarPantalla(string nombre){
        SceneManager.LoadScene(nombre);
    }
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volumen", 1f);
    }
    public void Salir(){
        Application.Quit();
    }
}
