using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BasePersonagem : MonoBehaviour, IDamageable
{
    [SerializeField] private Slider lifeBar; // Barra de vida do personagem
    private TextMeshProUGUI lifeText; // Texto exibindo a vida atual

    public int força;
    public int vidaAtual;
    public int vidaMaxima;
    public int defesa;
    public float duration;

    private Vector2 initialPos;
    public bool jaAtacou;
    public CharacterStatusGeneric characterStatus;

    void Start()
    {
        initialPos = transform.position;
    }

    // Configura o status do personagem a partir do CharacterStatus
    public void SetupStatus()
    {
        força = characterStatus.força;
        vidaAtual = characterStatus.vidaAtual;
        vidaMaxima = characterStatus.vidaMaxima;
        defesa = characterStatus.defesa;

        if (lifeBar != null)
        {
            lifeText = lifeBar.GetComponentInChildren<TextMeshProUGUI>();
            lifeBar.gameObject.SetActive(true);
            lifeBar.maxValue = vidaMaxima;
            UpdateLife();
        }
    }

    // Atualiza a barra de vida na interface
    private void UpdateLife()
    {
        lifeBar.value = vidaAtual;
        lifeText.text = $"{vidaAtual} / {vidaMaxima}";
    }

    // Recebe dano e atualiza a vida
    public void TakeDamage(int damage)
    {
        if (vidaAtual > 0)
        {
            vidaAtual -= damage; // Subtrai o dano da vida
            UpdateLife();
        }

        if (vidaAtual <= 0)
        {
            // Desativa o personagem e a barra de vida quando ele morre
            TurnModeManager.instance.aliadosPersonagens.Remove(this);
            TurnModeManager.instance.inimigosPersonagens.Remove(this);
            if (lifeBar != null)
                Destroy(lifeBar.gameObject);

            Destroy(gameObject); // Destroi o objeto
        }
    }

    // Move o personagem para uma nova posição
    public void MovePlayerToPos(Vector2 newPos)
    {
        StartCoroutine(MovePlayer(newPos));
    }

    private IEnumerator MovePlayer(Vector2 newPos)
    {
        float iterator = 0;
        while (iterator < duration)
        {
            float playerNewX = Mathf.Lerp(initialPos.x, newPos.x, iterator);
            float playerNewY = Mathf.Lerp(initialPos.y, newPos.y, iterator);
            transform.position = new Vector2(playerNewX, playerNewY);

            iterator += Time.deltaTime * duration;
            yield return null;
        }

        jaAtacou = true;
        TurnModeManager.instance.CheckIfAllCharactersAttacked(); // Verifica se todos os personagens atacaram
    }
}