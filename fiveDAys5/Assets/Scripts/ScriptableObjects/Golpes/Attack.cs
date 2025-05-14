using UnityEngine;

public abstract class Attack : ScriptableObject
{
    // Dano do ataque
    public int dano;

    // Nome do ataque
    public string nomeAtaque;

    // Ícone do ataque
    public Sprite iconeAtaque;

    // Animação associada ao ataque
    public RuntimeAnimatorController animatorController;

    // Método para executar o ataque
    public virtual void ExecutarAtaque(BasePersonagem alvo)
    {
        // Desativa o menu de interação de botões
        InteractButtonsController.instance.menu.SetActive(false);
    }
}