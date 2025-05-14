using UnityEngine;

public class SceneTimeController : MonoBehaviour
{
    // Delegado para notificar que o jogo foi pausado
    public delegate void OnPauseGame();
    public OnPauseGame onPauseGame;

    // Instância única do SceneTimeController
    public static SceneTimeController instance;

    // Armazena o tempo do jogo
    public float sceneTime;

    private void Awake()
    {
        // Garante que haja apenas uma instância do SceneTimeController
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneTime = Time.timeScale; // Inicializa o tempo da cena com o valor do Time.timeScale
    }

    // Função para pausar o jogo
    public void PausarJogo()
    {
        sceneTime = 0; // Congela o tempo
        onPauseGame?.Invoke(); // Invoca o evento de pausa
    }

    // Função que verifica se o jogo está pausado
    public bool isPaused()
    {
        return sceneTime == 0;
    }
}