using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

[CreateAssetMenu(menuName = "Ataque/AtaqueB�sico")]
public class BasicAttack : Attack
{
    // M�todo que executa o ataque b�sico
    public override async void ExecutarAtaque(BasePersonagem alvo)
    {
        // Obt�m a dura��o do personagem que est� atacando
        float dura��o = TurnModeManager.instance.QuemEstaAtacando().duration;

        // Chama o m�todo base para o ataque
        base.ExecutarAtaque(alvo);

        // Move o personagem at� a posi��o do alvo
        TurnModeManager.instance.QuemEstaAtacando().MovePlayerToPos(new Vector2(alvo.transform.position.x, alvo.transform.position.y));

        // Aguarda o tempo necess�rio para a dura��o do movimento
        await Task.Delay(Mathf.CeilToInt(dura��o) * 250);

        // Causa dano ao alvo
        alvo.TakeDamage(dano);
    }
}