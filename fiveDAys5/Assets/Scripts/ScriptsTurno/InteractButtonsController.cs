using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

public class InteractButtonsController : MonoBehaviour
{
    [Header("Essential")]
    public GameObject menu;                      // Referência para o menu de interações (botões)
    public Animator attackMenuAnim;              // Animador do menu de ataque
    [SerializeField] Button attackButton;        // Botão para abrir o menu de ataque
    [SerializeField] TextMeshProUGUI[] attacksText;  // Texto que será exibido para cada ataque
    public List<Attack> ataques;                 // Lista de ataques disponíveis para o personagem

    [Header("Configurable")]
    [SerializeField] Image[] attackIcons = new Image[4]; // Ícones dos ataques
    [SerializeField] float menuDistance;            // Distância para posicionar o menu em relação ao personagem
    [SerializeField] Sprite[] originalSprites = new Sprite[4]; // Sprites originais dos ícones de ataque

    // Variáveis não-mostradas no editor
    public static InteractButtonsController instance;

    private void Awake()
    {
        // Salva os sprites originais dos ícones de ataque ao iniciar o jogo
        for (int i = 0; i < attacksText.Length; i++)
        {
            originalSprites[i] = attackIcons[i].sprite;
        }

        // Garante que exista apenas uma instância deste controlador
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
        // Desativa o menu de ataque no início
        attackMenuAnim.gameObject.SetActive(false);
        // Adiciona o listener ao botão de ataque para abrir o menu
        attackButton.onClick.AddListener(OpenMenu);
    }

    // Função que abre ou fecha o menu de ataques
    public void OpenMenu()
    {
        // Alterna a ativação do menu de ataque
        attackMenuAnim.gameObject.SetActive(!attackMenuAnim.isActiveAndEnabled);
        // Exibe no console quem está atacando
        print(TurnModeManager.instance.QuemEstaAtacando());
        // Atualiza a lista de ataques com os ataques do personagem atual
        ataques = TurnModeManager.instance.QuemEstaAtacando().GetComponent<Aliados>().ataques;
    }

    // Função que pode ser chamada para rodar algo durante a interação (atualmente não usada)
    public void Run()
    {

    }

    // Função que configura a posição e os ataques do menu com base na posição do personagem
    public void SetupMenu(Vector2 newPos)
    {
        // Define a posição do menu com base na posição do personagem e a distância configurada
        menu.transform.position = new Vector2(newPos.x + menuDistance, newPos.y);

        // Para cada ataque disponível, configura o ícone e o texto correspondente
        for (int i = 0; i < attacksText.Length; i++)
        {
            // Reseta o sprite do ícone para o original
            attackIcons[i].sprite = originalSprites[i];

            // Se o ataque não for nulo, configura o nome e ícone
            if (ataques[i] != null)
            {
                attacksText[i].text = ataques[i].name;
                attackIcons[i].sprite = ataques[i].iconeAtaque;
            }
            // Caso contrário, exibe um texto de "------"
            else
            {
                attacksText[i].text = "------";
            }
        }
    }

    // Função que move para o próximo personagem da vez
    public void NextPlayer()
    {
        // Ativa o menu novamente
        menu.SetActive(true);
        // Desativa a animação do menu de ataques
        attackMenuAnim.gameObject.SetActive(false);
        // Reconfigura o menu com base na posição do próximo personagem
        SetupMenu(TurnModeManager.instance.QuemEstaAtacando().transform.position);
        // Define o foco do evento para o botão de ataque
        EventSystem.current.SetSelectedGameObject(attackButton.gameObject);
    }

    // Função que executa o ataque de acordo com a escolha do jogador
    public void SetMove(int whatMove)
    {
        // Executa o ataque escolhido no alvo
        ataques[whatMove].ExecutarAtaque(TurnModeManager.instance.EncontrarAlvo());
    }
}