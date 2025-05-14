using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    // Vida do inimigo
    [SerializeField] int vida;

    // Lista de ataques que o inimigo pode executar
    [SerializeField] List<BasicAttack> ataques;

    // Referência ao personagem inimigo
    BasePersonagem enemyCharacter;

    void Start()
    {
        // Inicializa a referência ao personagem
        enemyCharacter = GetComponent<BasePersonagem>();
    }

    // Método que executa o ataque do inimigo
    public void Attack()
    {
        if (!enemyCharacter.jaAtacou && TurnModeManager.instance.turno == Turnos.EnemyTurn)
        {
            // Escolhe um ataque aleatório da lista de ataques
            int ataqueEscolhido = Random.Range(0, ataques.Count);
            BasicAttack ataque = ataques[ataqueEscolhido];

            // Executa o ataque no alvo
            ataque.ExecutarAtaque(TurnModeManager.instance.EncontrarAlvo());
        }
    }
}