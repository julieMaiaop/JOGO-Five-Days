using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public enum Turnos
{
    PlayerTurn,
    EnemyTurn
}

public class TurnModeManager : MonoBehaviour
{
    // Lista de inimigos e aliados
    [Header("Essential")]
    public List<EnemyAI> inimigos;
    public List<Aliados> aliados;

    [Tooltip("UI para vitoria ou derrota")]
    [SerializeField] private GameObject endMenu;

    // Controle de turno
    [Header("Debug")]
    [SerializeField] private bool hasOnlyOneEnemy;
    public int turnoDeQualPersonagem;
    public Turnos turno;

    // Refer�ncias para personagens
    [HideInInspector] public List<BasePersonagem> aliadosPersonagens;
    [HideInInspector] public List<BasePersonagem> inimigosPersonagens;

    public static TurnModeManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        turno = Turnos.PlayerTurn; // Inicia com o turno do jogador
        endMenu.SetActive(false); // Desativa o menu de fim de jogo
        turnoDeQualPersonagem = 0; // Come�a com o primeiro personagem
    }
    // Inicia o ataque do primeiro aliado
    public void FirstAllyAttack()
    {
        InteractButtonsController.instance.ataques = QuemEstaAtacando().GetComponent<Aliados>().ataques;
        InteractButtonsController.instance.SetupMenu(aliados[turnoDeQualPersonagem].transform.position);
        Debug.Log("Primeiro ataque do aliado");
    }

    // Fun��o chamada no Update para gerenciar o estado do jogo
    private void Update()
    {
        hasOnlyOneEnemy = inimigos.Count == 1; // Verifica se h� apenas um inimigo
    }

    // Fun��o que finaliza o jogo
    private void EndGame()
    {
        endMenu.SetActive(true); // Ativa o menu de fim de jogo
        Time.timeScale = 0f; // Pausa o tempo
    }

    // Verifica se todos os personagens j� atacaram
    public void CheckIfAllCharactersAttacked()
    {
        if (turno == Turnos.PlayerTurn)
        {
            if (inimigos.Count <= 0)
            {
                EndGame(); // Fim do jogo se n�o houver inimigos
                return;
            }

            if (JaAtacaram(aliadosPersonagens))
            {
                turno = Turnos.EnemyTurn;
                InteractButtonsController.instance.menu.SetActive(false); // Desativa o menu de intera��es
                turnoDeQualPersonagem = 0;
                inimigos[turnoDeQualPersonagem].Attack(); // Inicia o ataque do inimigo
            }
            else
            {
                turnoDeQualPersonagem++;
                InteractButtonsController.instance.NextPlayer(); // Passa para o pr�ximo personagem do jogador
            }
        }
        else if (turno == Turnos.EnemyTurn)
        {
            if (aliados.Count <= 0)
            {
                EndGame(); // Fim do jogo se n�o houver aliados
                return;
            }

            turnoDeQualPersonagem = 0;
            if (JaAtacaram(inimigosPersonagens))
            {
                turno = Turnos.PlayerTurn;
                ResetAttackStatus(); // Reseta o status de ataque dos personagens
                InteractButtonsController.instance.SetupMenu(aliados[turnoDeQualPersonagem].transform.position);
                InteractButtonsController.instance.menu.SetActive(true); // Ativa o menu de intera��es
            }
            else
            {
                turnoDeQualPersonagem++;
            }
        }
    }

    // Reseta o status de ataque de todos os personagens
    private void ResetAttackStatus()
    {
        foreach (var personagem in aliadosPersonagens)
        {
            personagem.jaAtacou = false;
        }
        foreach (var personagem in inimigosPersonagens)
        {
            personagem.jaAtacou = false;
        }
    }

    #region Utils

    // Verifica se todos os personagens atacaram
    public bool JaAtacaram(List<BasePersonagem> personagens)
    {
        foreach (var personagem in personagens)
        {
            if (!personagem.jaAtacou)
                return false; // Se algum personagem n�o atacou, retorna false
        }
        return true;
    }

    // Retorna o personagem que est� atacando atualmente
    public BasePersonagem QuemEstaAtacando()
    {
        List<BasePersonagem> personagems = turno == Turnos.PlayerTurn ? aliadosPersonagens : inimigosPersonagens;
        if (personagems == null || personagems[turnoDeQualPersonagem].jaAtacou)
            return null;
        return personagems[turnoDeQualPersonagem];
    }

    // Encontra um alvo para o ataque
    public BasePersonagem EncontrarAlvo()
    {
        if (hasOnlyOneEnemy && turno == Turnos.PlayerTurn)
        {
            return inimigos[0].GetComponent<BasePersonagem>(); // Se houver um �nico inimigo, o alvo � ele
        }
        else if (turno == Turnos.EnemyTurn)
        {
            int aliadoEscolhido = Random.Range(0, aliados.Count); // Escolhe um aliado aleatoriamente
            return aliadosPersonagens[aliadoEscolhido];
        }
        return null;
    }

    #endregion
}