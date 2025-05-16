using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public PlayerController playerController;  // Referência ao jogador
    public Enemy enemy;                        // Referência ao inimigo
    public Character playerCharacter;          // Referência ao personagem do jogador
    public Character enemyCharacter;           // Referência ao personagem do inimigo

    public GameObject victoryPanel;            // Painel de Vitória
    public GameObject deadPanel;            // Painel de Vitória
    public bool canEnemyAttack = true;         // Flag de controle para o inimigo atacar (adicionei essa linha)

    private void Awake()
    {
        instance = this;
    }

    // Começa o turno do jogador
    public void PlayerTurn()
    {
        enemy.GetComponent<Enemy>().enabled = false;  // Desativa o script Enemy
        canEnemyAttack = false;  // Desativa a capacidade de ataque do inimigo

        // Ativa os botões para o jogador
        playerController.Attack();
    }

    // Começa o turno do inimigo
    public void EnemyTurn()
    {
        // Se a flag `canEnemyAttack` estiver ativada, o inimigo pode atacar
        if (canEnemyAttack)
        {
            enemy.Attack();
        }

        // Verifica se a vida do inimigo ou do jogador acabou
        if (playerCharacter.currentHealth <= 0)
        {
            deadPanel.SetActive(true);
        }
        else if (enemyCharacter.currentHealth <= 0)
        {
            victoryPanel.SetActive(true);
        }
        else
        {
            // Se ninguém morreu, passa o turno de volta para o jogador
            Invoke("PlayerTurn", 1f);
        }
    }
}