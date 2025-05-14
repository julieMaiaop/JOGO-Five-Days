using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class IniciarLuta : MonoBehaviour
{
    // Delegate que ser� chamado para iniciar a batalha
    public delegate void OnStartBattle();
    public OnStartBattle onStartBattle;

    // Cena para a qual o jogo ir� carregar
    [SerializeField] string cenaEscolhida;

    // Status dos inimigos
    [SerializeField] CharacterStatusGeneric[] enemiesStatus;

    // Quando o jogador colide com o objeto que possui este script, come�a a batalha
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Carrega a cena de batalha de forma aditiva, ou seja, a cena atual n�o � destru�da
        SceneManager.LoadScene(cenaEscolhida, LoadSceneMode.Additive);

        // Pausa o jogo e define o tempo como 0
        SceneTimeController.instance.sceneTime = 0;
        SceneTimeController.instance.PausarJogo();

        // Invoca a fun��o WaitSomeTime ap�s um pequeno atraso
        Invoke("WaitSomeTime", 0.3f);
    }

    // M�todo chamado ap�s o tempo de espera
    void WaitSomeTime()
    {
        // Prepara os personagens na batalha com os status definidos
        RecieveInfoManager.instance.SetupCharacters(PlayerPartyController.instance.partyAtual, enemiesStatus.ToList());
    }
}