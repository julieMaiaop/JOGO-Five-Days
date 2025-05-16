using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Character playerCharacter;  // Refer�ncia ao personagem do jogador

    // M�todo para o jogador atacar
    public void Attack()
    {
        // Apenas tira a vida do inimigo
        Character enemy = BattleManager.instance.enemyCharacter;  // Refer�ncia ao inimigo
        playerCharacter.DealDamage(enemy);

        // Fim do turno do jogador, o inimigo age agora
        BattleManager.instance.EnemyTurn();
    }

    // M�todo para o jogador defender
    public void Defend()
    {
        // Ativa a defesa do jogador
        playerCharacter.isDefending = true;

        // Fim do turno do jogador, o inimigo age agora
        BattleManager.instance.EnemyTurn();
    }
}