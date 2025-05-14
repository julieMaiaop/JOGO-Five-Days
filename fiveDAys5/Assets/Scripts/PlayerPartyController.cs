using UnityEngine;
using System.Collections.Generic;

public class PlayerPartyController : MonoBehaviour
{
    [Header("Party do Player")]
    [SerializeField] private List<CharacterStatusGeneric> playerParty = new List<CharacterStatusGeneric>();  // Lista privada de personagens do jogador

    public List<CharacterStatusGeneric> partyAtual { get; private set; } // Lista pública somente leitura de personagens ativos

    public static PlayerPartyController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garante que o objeto não seja destruído ao carregar uma nova cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        partyAtual = new List<CharacterStatusGeneric>(playerParty); // Inicializa a lista de personagens ativos
    }

    // Função para curar todos os personagens da party
    public void CurarTodos()
    {
        foreach (var personagem in playerParty)
        {
            personagem.vidaAtual = personagem.vidaMaxima; // Restaura a vida de todos os personagens
        }
    }
}