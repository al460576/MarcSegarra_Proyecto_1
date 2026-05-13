using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugar : MonoBehaviour
{
    public void CambiarPantalla(string nombre){
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }
    public void VolverAlJuego()
    {
        PlayerMove playerMove = FindObjectOfType<PlayerMove>();
        if (playerMove != null)        {
            playerMove.CloseOptions();
        }
    }
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volumen", 1f);
    }

    public void Salir(){
        Application.Quit();
    }
}
