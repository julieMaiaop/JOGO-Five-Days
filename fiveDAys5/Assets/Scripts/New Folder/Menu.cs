using UnityEngine;



using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("JUlie");
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}


