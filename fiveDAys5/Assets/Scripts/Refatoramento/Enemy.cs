using UnityEngine;

public class Enemy : Character
{
    // Método que determina a ação do inimigo (atacar)
    public void Act()
    {
        // O inimigo sempre ataca
        Attack();

        // Após a ação do inimigo, passa para o turno do jogador
        BattleManager.instance.PlayerTurn();
    }

    private void Attack()
    {
        // O inimigo ataca o jogador
        Character player = BattleManager.instance.playerCharacter;  // Referência ao jogador
        DealDamage(player);  // O inimigo causa dano no jogador
    }
}