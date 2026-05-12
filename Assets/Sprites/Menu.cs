using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambiarPantalla(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir(){
        Application.Quit();
    }
}
