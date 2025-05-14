using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RecieveInfoManager : MonoBehaviour
{
    // Instância única
    public static RecieveInfoManager instance;

    // Listas que armazenam os personagens aliados e inimigos originais
    private List<Aliados> aliadosOriginais = new List<Aliados>();
    private List<EnemyAI> inimigosOriginais = new List<EnemyAI>();

    private void Awake()
    {
        TurnModeManager turnModeManager = TurnModeManager.instance;

        // Garante que exista apenas uma instância do RecieveInfoManager
        if (instance == null) instance = this;

        // Desativa todos os aliados e inimigos originais
        for (int i = 0; i < turnModeManager.aliados.Count; i++)
        {
            aliadosOriginais.Add(turnModeManager.aliados[i]);
            turnModeManager.aliados[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < turnModeManager.inimigos.Count; i++)
        {
            inimigosOriginais.Add(turnModeManager.inimigos[i]);
            turnModeManager.inimigos[i].gameObject.SetActive(false);
        }

        // Limpa as listas de aliados e inimigos no TurnModeManager
        turnModeManager.aliados.Clear();
        turnModeManager.aliadosPersonagens.Clear();
        turnModeManager.inimigos.Clear();
        turnModeManager.inimigosPersonagens.Clear();
    }

    // Configura os personagens para a batalha
    public void SetupCharacters(List<CharacterStatusGeneric> playerStatus, List<CharacterStatusGeneric> enemiesStatus)
    {
        StartCoroutine(Setup(playerStatus, enemiesStatus));
    }

    // Coroutine para configurar os personagens durante a batalha
    IEnumerator Setup(List<CharacterStatusGeneric> playerStatus, List<CharacterStatusGeneric> enemyStatus)
    {
        TurnModeManager turnModeManager = TurnModeManager.instance;

        // Adiciona os aliados à batalha
        for (int i = 0; i < playerStatus.Count; i++)
        {
            turnModeManager.aliados.Add(aliadosOriginais[i]);
            turnModeManager.aliadosPersonagens.Add(aliadosOriginais[i].GetComponent<BasePersonagem>());
            turnModeManager.aliadosPersonagens[i].characterStatus = playerStatus[i];
            turnModeManager.aliadosPersonagens[i].SetupStatus();
            turnModeManager.aliados[i].gameObject.SetActive(true);
        }

        // Adiciona os inimigos à batalha
        for (int i = 0; i < enemyStatus.Count; i++)
        {
            turnModeManager.inimigos.Add(inimigosOriginais[i]);
            turnModeManager.inimigosPersonagens.Add(inimigosOriginais[i].GetComponent<BasePersonagem>());
            turnModeManager.inimigosPersonagens[i].characterStatus = Instantiate(enemyStatus[i]);
            turnModeManager.inimigosPersonagens[i].SetupStatus();
            turnModeManager.inimigos[i].gameObject.SetActive(true);
        }

        // Espera um pouco antes de iniciar o combate
        yield return new WaitForSeconds(0.1f);

        // Inicia o primeiro ataque do aliado
        TurnModeManager.instance.FirstAllyAttack();
    }
}