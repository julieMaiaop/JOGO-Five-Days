using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReturnToScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // Método para retornar à cena anterior
    public void ReturnScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f; // Garantir que o tempo do jogo seja restaurado
    }
}