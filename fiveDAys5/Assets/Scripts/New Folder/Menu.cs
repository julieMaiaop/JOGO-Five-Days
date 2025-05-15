using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void IniciarJogo(string tp)
    {
        SceneManager.LoadScene(tp);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}


