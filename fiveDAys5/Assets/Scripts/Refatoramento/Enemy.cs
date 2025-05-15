using UnityEngine;

public class Enemy : Character
{
    // M�todo que determina a a��o do inimigo (atacar)
    public void Act()
    {
        // O inimigo sempre ataca
        Attack();

        // Ap�s a a��o do inimigo, passa para o turno do jogador
        BattleManager.instance.PlayerTurn();
    }

    private void Attack()
    {
        // O inimigo ataca o jogador
        Character player = BattleManager.instance.playerCharacter;  // Refer�ncia ao jogador
        DealDamage(player);  // O inimigo causa dano no jogador
    }
}