using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Character enemyCharacter;  // Refer�ncia ao personagem do inimigo

    // M�todo do inimigo para atacar o jogador
    public void Attack()
    {
        // Apenas tira a vida do jogador
        Character player = BattleManager.instance.playerCharacter;  // Refer�ncia ao jogador
        enemyCharacter.DealDamage(player);
    }
}