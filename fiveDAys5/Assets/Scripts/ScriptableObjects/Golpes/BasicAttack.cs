using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

[CreateAssetMenu(menuName = "Ataque/AtaqueBásico")]
public class BasicAttack : Attack
{
    // Método que executa o ataque básico
    public override async void ExecutarAtaque(BasePersonagem alvo)
    {
        // Obtém a duração do personagem que está atacando
        float duração = TurnModeManager.instance.QuemEstaAtacando().duration;

        // Chama o método base para o ataque
        base.ExecutarAtaque(alvo);

        // Move o personagem até a posição do alvo
        TurnModeManager.instance.QuemEstaAtacando().MovePlayerToPos(new Vector2(alvo.transform.position.x, alvo.transform.position.y));

        // Aguarda o tempo necessário para a duração do movimento
        await Task.Delay(Mathf.CeilToInt(duração) * 250);

        // Causa dano ao alvo
        alvo.TakeDamage(dano);
    }
}