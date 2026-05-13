using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public void CambiarPantalla(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir(){
        Application.Quit();
    }
}


