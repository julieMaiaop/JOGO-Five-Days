using UnityEngine;

public abstract class Attack : ScriptableObject
{
    // Dano do ataque
    public int dano;

    // Nome do ataque
    public string nomeAtaque;

    // �cone do ataque
    public Sprite iconeAtaque;

    // Anima��o associada ao ataque
    public RuntimeAnimatorController animatorController;

    // M�todo para executar o ataque
    public virtual void ExecutarAtaque(BasePersonagem alvo)
    {
        // Desativa o menu de intera��o de bot�es
        InteractButtonsController.instance.menu.SetActive(false);
    }
}