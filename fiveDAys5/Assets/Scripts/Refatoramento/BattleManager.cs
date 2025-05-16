using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public PlayerController playerController;  // Refer�ncia ao jogador
    public Enemy enemy;                        // Refer�ncia ao inimigo
    public Character playerCharacter;          // Refer�ncia ao personagem do jogador
    public Character enemyCharacter;           // Refer�ncia ao personagem do inimigo

    public GameObject victoryPanel;            // Painel de Vit�ria
    public GameObject deadPanel;            // Painel de Vit�ria
    public bool canEnemyAttack = true;         // Flag de controle para o inimigo atacar (adicionei essa linha)

    private void Awake()
    {
        instance = this;
    }

    // Come�a o turno do jogador
    public void PlayerTurn()
    {
        enemy.GetComponent<Enemy>().enabled = false;  // Desativa o script Enemy
        canEnemyAttack = false;  // Desativa a capacidade de ataque do inimigo

        // Ativa os bot�es para o jogador
        playerController.Attack();
    }

    // Come�a o turno do inimigo
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
            // Se ningu�m morreu, passa o turno de volta para o jogador
            Invoke("PlayerTurn", 1f);
        }
    }
}