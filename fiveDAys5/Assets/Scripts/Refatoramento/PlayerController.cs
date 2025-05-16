using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Character playerCharacter;  // Referência ao personagem do jogador

    // Método para o jogador atacar
    public void Attack()
    {
        // Apenas tira a vida do inimigo
        Character enemy = BattleManager.instance.enemyCharacter;  // Referência ao inimigo
        playerCharacter.DealDamage(enemy);

        // Fim do turno do jogador, o inimigo age agora
        BattleManager.instance.EnemyTurn();
    }

    // Método para o jogador defender
    public void Defend()
    {
        // Ativa a defesa do jogador
        playerCharacter.isDefending = true;

        // Fim do turno do jogador, o inimigo age agora
        BattleManager.instance.EnemyTurn();
    }
}