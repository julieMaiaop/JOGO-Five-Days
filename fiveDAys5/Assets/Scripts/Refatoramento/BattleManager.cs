using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public PlayerController player;   // Refer�ncia ao jogador
    public Enemy enemy;               // Refer�ncia ao inimigo
    public Button attackButton;       // Refer�ncia ao bot�o de ataque
    public Button defendButton;       // Refer�ncia ao bot�o de defesa
    public Button fleeButton;         // Refer�ncia ao bot�o de fuga
    public GameObject endGamePanel;   // Refer�ncia ao painel de fim de jogo
    public TMP_Text resultText;           // Refer�ncia ao texto de resultado do painel

    public Character playerCharacter;  // Refer�ncia direta ao personagem do jogador
    public Character enemyCharacter;   // Refer�ncia direta ao personagem do inimigo

    private void Awake()
    {
        instance = this;
    }

    // Come�a o turno do jogador
    public void PlayerTurn()
    {
        // Ativa os bot�es de a��o do jogador
        attackButton.interactable = true;
        defendButton.interactable = true;
        fleeButton.interactable = true;

        // Atualiza o personagem ativo do jogador
        player.UpdateActiveCharacter();
    }

    // Come�a o turno do inimigo
    public void EnemyTurn()
    {
        // Desativa os bot�es de a��o enquanto o inimigo est� jogando
        attackButton.interactable = false;
        defendButton.interactable = false;
        fleeButton.interactable = false;

        // O inimigo sempre ataca
        enemy.Act();

        // Verifica se o inimigo morreu ap�s o ataque
        if (enemyCharacter.currentHealth <= 0)
        {
            EndBattle(false);  // Se o inimigo morrer, o jogador ganha
            return;
        }

        // Depois que o inimigo terminar seu turno, o jogo continua
        Invoke("PlayerTurn", 1f);  // Chama a fun��o para o jogador jogar novamente ap�s 1 segundo
    }

    // Fun��o chamada quando a batalha termina
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

        // Desativa os bot�es de a��o
        attackButton.interactable = false;
        defendButton.interactable = false;
        fleeButton.interactable = false;
    }
}