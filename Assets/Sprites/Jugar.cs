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

    public void Salir(){
        Application.Quit();
    }
}
