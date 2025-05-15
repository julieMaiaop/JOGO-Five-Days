using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public string characterName;    // Nome do personagem
    public int maxHealth;           // Vida máxima
    public int currentHealth;       // Vida atual
    public int damage;              // Dano do personagem
    public Slider healthSlider;     // Referência ao Slider da UI
    public bool isDefending;        // Se o personagem está defendendo

    // Método para causar dano em outro personagem
    public void DealDamage(Character target)
    {
        int effectiveDamage = isDefending ? damage / 2 : damage;  // Se estiver defendendo, o dano é reduzido
        target.TakeDamage(effectiveDamage);
    }

    // Atualiza o slider de vida
    void UpdateHealthSlider()
    {
        healthSlider.value = (float)currentHealth / maxHealth;  // Atualiza a barra de vida com a vida atual
    }

    // Método para o personagem receber dano
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Subtrai o dano da vida atual
        if (currentHealth < 0)
        {
            currentHealth = 0;  // Garante que a vida não fique negativa
        }

        // Atualiza o slider após sofrer dano
        UpdateHealthSlider();
    }

    // Método para resetar a defesa (caso o personagem pare de defender)
    public void ResetDefense()
    {
        isDefending = false;  // Reseta a defesa
    }
}