using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{
    public void IrAOpciones()
    {
        SceneManager.LoadScene("Opciones", LoadSceneMode.Additive);
    }
}
