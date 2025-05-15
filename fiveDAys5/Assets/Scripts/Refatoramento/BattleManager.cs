using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public PlayerController player;   // Referência ao jogador
    public Enemy enemy;               // Referência ao inimigo
    public Button attackButton;       // Referência ao botão de ataque
    public Button defendButton;       // Referência ao botão de defesa
    public Button fleeButton;         // Referência ao botão de fuga
    public GameObject endGamePanel;   // Referência ao painel de fim de jogo
    public TMP_Text resultText;           // Referência ao texto de resultado do painel

    public Character playerCharacter;  // Referência direta ao personagem do jogador
    public Character enemyCharacter;   // Referência direta ao personagem do inimigo

    private void Awake()
    {
        instance = this;
    }

    // Começa o turno do jogador
    public void PlayerTurn()
    {
        // Ativa os botões de ação do jogador
        attackButton.interactable = true;
        defendButton.interactable = true;
        fleeButton.interactable = true;

        // Atualiza o personagem ativo do jogador
        player.UpdateActiveCharacter();
    }

    // Começa o turno do inimigo
    public void EnemyTurn()
    {
        // Desativa os botões de ação enquanto o inimigo está jogando
        attackButton.interactable = false;
        defendButton.interactable = false;
        fleeButton.interactable = false;

        // O inimigo sempre ataca
        enemy.Act();

        // Verifica se o inimigo morreu após o ataque
        if (enemyCharacter.currentHealth <= 0)
        {
            EndBattle(false);  // Se o inimigo morrer, o jogador ganha
            return;
        }

        // Depois que o inimigo terminar seu turno, o jogo continua
        Invoke("PlayerTurn", 1f);  // Chama a função para o jogador jogar novamente após 1 segundo
    }

    // Função chamada quando a batalha termina
    public void EndBattle(bool playerWon)
    {
        // Exibe o painel de fim de jogo
        endGamePanel.SetActive(true);

        if (playerWon)
        {
            resultText.text = "You Win!";  // Se o jogador ganhou
        }
        else
        {
            resultText.text = "You Lose!";  // Se o jogador perdeu
        }

        // Desativa os botões de ação
        attackButton.interactable = false;
        defendButton.interactable = false;
        fleeButton.interactable = false;
    }
}