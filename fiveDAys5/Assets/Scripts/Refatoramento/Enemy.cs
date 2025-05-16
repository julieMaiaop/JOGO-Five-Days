using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Character enemyCharacter;  // Referência ao personagem do inimigo

    // Método do inimigo para atacar o jogador
    public void Attack()
    {
        // Apenas tira a vida do jogador
        Character player = BattleManager.instance.playerCharacter;  // Referência ao jogador
        enemyCharacter.DealDamage(player);
    }
}