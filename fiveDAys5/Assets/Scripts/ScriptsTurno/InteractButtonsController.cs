using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

public class InteractButtonsController : MonoBehaviour
{
    [Header("Essential")]
    public GameObject menu;                      // Refer�ncia para o menu de intera��es (bot�es)
    public Animator attackMenuAnim;              // Animador do menu de ataque
    [SerializeField] Button attackButton;        // Bot�o para abrir o menu de ataque
    [SerializeField] TextMeshProUGUI[] attacksText;  // Texto que ser� exibido para cada ataque
    public List<Attack> ataques;                 // Lista de ataques dispon�veis para o personagem

    [Header("Configurable")]
    [SerializeField] Image[] attackIcons = new Image[4]; // �cones dos ataques
    [SerializeField] float menuDistance;            // Dist�ncia para posicionar o menu em rela��o ao personagem
    [SerializeField] Sprite[] originalSprites = new Sprite[4]; // Sprites originais dos �cones de ataque

    // Vari�veis n�o-mostradas no editor
    public static InteractButtonsController instance;

    private void Awake()
    {
        // Salva os sprites originais dos �cones de ataque ao iniciar o jogo
        for (int i = 0; i < attacksText.Length; i++)
        {
            originalSprites[i] = attackIcons[i].sprite;
        }

        // Garante que exista apenas uma inst�ncia deste controlador
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Desativa o menu de ataque no in�cio
        attackMenuAnim.gameObject.SetActive(false);
        // Adiciona o listener ao bot�o de ataque para abrir o menu
        attackButton.onClick.AddListener(OpenMenu);
    }

    // Fun��o que abre ou fecha o menu de ataques
    public void OpenMenu()
    {
        // Alterna a ativa��o do menu de ataque
        attackMenuAnim.gameObject.SetActive(!attackMenuAnim.isActiveAndEnabled);
        // Exibe no console quem est� atacando
        print(TurnModeManager.instance.QuemEstaAtacando());
        // Atualiza a lista de ataques com os ataques do personagem atual
        ataques = TurnModeManager.instance.QuemEstaAtacando().GetComponent<Aliados>().ataques;
    }

    // Fun��o que pode ser chamada para rodar algo durante a intera��o (atualmente n�o usada)
    public void Run()
    {

    }

    // Fun��o que configura a posi��o e os ataques do menu com base na posi��o do personagem
    public void SetupMenu(Vector2 newPos)
    {
        // Define a posi��o do menu com base na posi��o do personagem e a dist�ncia configurada
        menu.transform.position = new Vector2(newPos.x + menuDistance, newPos.y);

        // Para cada ataque dispon�vel, configura o �cone e o texto correspondente
        for (int i = 0; i < attacksText.Length; i++)
        {
            // Reseta o sprite do �cone para o original
            attackIcons[i].sprite = originalSprites[i];

            // Se o ataque n�o for nulo, configura o nome e �cone
            if (ataques[i] != null)
            {
                attacksText[i].text = ataques[i].name;
                attackIcons[i].sprite = ataques[i].iconeAtaque;
            }
            // Caso contr�rio, exibe um texto de "------"
            else
            {
                attacksText[i].text = "------";
            }
        }
    }

    // Fun��o que move para o pr�ximo personagem da vez
    public void NextPlayer()
    {
        // Ativa o menu novamente
        menu.SetActive(true);
        // Desativa a anima��o do menu de ataques
        attackMenuAnim.gameObject.SetActive(false);
        // Reconfigura o menu com base na posi��o do pr�ximo personagem
        SetupMenu(TurnModeManager.instance.QuemEstaAtacando().transform.position);
        // Define o foco do evento para o bot�o de ataque
        EventSystem.current.SetSelectedGameObject(attackButton.gameObject);
    }

    // Fun��o que executa o ataque de acordo com a escolha do jogador
    public void SetMove(int whatMove)
    {
        // Executa o ataque escolhido no alvo
        ataques[whatMove].ExecutarAtaque(TurnModeManager.instance.EncontrarAlvo());
    }
}