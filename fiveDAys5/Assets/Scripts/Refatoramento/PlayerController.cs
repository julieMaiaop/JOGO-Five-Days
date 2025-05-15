using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Character playerCharacter;  // Personagem do jogador
    private bool isPlayerTurn = true;  // Flag para verificar se � a vez do jogador

    // Fun��o de ataque
    public void Attack()
    {
        if (isPlayerTurn)
        {
            // Escolhe o inimigo (apenas 1 inimigo agora)
            Character enemy = BattleManager.instance.enemyCharacter;  // Refer�ncia ao inimigo

            // Realiza o ataque
            playerCharacter.DealDamage(enemy);

            // Passa para o turno do inimigo
            isPlayerTurn = false;
            BattleManager.instance.EnemyTurn();  // Chama a fun��o que inicia o turno do inimigo
        }
    }

    // Fun��o de defesa
    public void Defend()
    {
        if (isPlayerTurn)
        {
            // O personagem come�a a defender
            playerCharacter.isDefending = true;

            // Ap�s a defesa, passa para o turno do inimigo
            isPlayerTurn = false;
            BattleManager.instance.EnemyTurn();
        }
    }

    // Fun��o de fuga
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
        // Para 1 contra 1, apenas o jogador � destacado com a cor verde
        playerCharacter.GetComponent<SpriteRenderer>().color = Color.green;
    }
}