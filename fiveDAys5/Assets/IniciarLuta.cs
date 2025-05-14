using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class IniciarLuta : MonoBehaviour
{
    // Delegate que será chamado para iniciar a batalha
    public delegate void OnStartBattle();
    public OnStartBattle onStartBattle;

    // Cena para a qual o jogo irá carregar
    [SerializeField] string cenaEscolhida;

    // Status dos inimigos
    [SerializeField] CharacterStatusGeneric[] enemiesStatus;

    // Quando o jogador colide com o objeto que possui este script, começa a batalha
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Carrega a cena de batalha de forma aditiva, ou seja, a cena atual não é destruída
        SceneManager.LoadScene(cenaEscolhida, LoadSceneMode.Additive);

        // Pausa o jogo e define o tempo como 0
        SceneTimeController.instance.sceneTime = 0;
        SceneTimeController.instance.PausarJogo();

        // Invoca a função WaitSomeTime após um pequeno atraso
        Invoke("WaitSomeTime", 0.3f);
    }

    // Método chamado após o tempo de espera
    void WaitSomeTime()
    {
        // Prepara os personagens na batalha com os status definidos
        RecieveInfoManager.instance.SetupCharacters(PlayerPartyController.instance.partyAtual, enemiesStatus.ToList());
    }
}