using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Character playerCharacter;  // Personagem do jogador
    private bool isPlayerTurn = true;  // Flag para verificar se é a vez do jogador

    // Função de ataque
    public void Attack()
    {
        if (isPlayerTurn)
        {
            // Escolhe o inimigo (apenas 1 inimigo agora)
            Character enemy = BattleManager.instance.enemyCharacter;  // Referência ao inimigo

            // Realiza o ataque
            playerCharacter.DealDamage(enemy);

            // Passa para o turno do inimigo
            isPlayerTurn = false;
            BattleManager.instance.EnemyTurn();  // Chama a função que inicia o turno do inimigo
        }
    }

    // Função de defesa
    public void Defend()
    {
        if (isPlayerTurn)
        {
            // O personagem começa a defender
            playerCharacter.isDefending = true;

            // Após a defesa, passa para o turno do inimigo
            isPlayerTurn = false;
            BattleManager.instance.EnemyTurn();
        }
    }

    // Função de fuga
    public void Flee()
    {
        if (isPlayerTurn)
        {
            // Se o jogador fugir, nada acontece e passa para o turno do inimigo
            isPlayerTurn = false;
            BattleManager.instance.EnemyTurn();
        }
    }

    // Atualiza a cor do personagem ativo
    public void UpdateActiveCharacter()
    {
        // Para 1 contra 1, apenas o jogador é destacado com a cor verde
        playerCharacter.GetComponent<SpriteRenderer>().color = Color.green;
    }
}