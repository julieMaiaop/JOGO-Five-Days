using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public string characterName;    // Nome do personagem
    public int maxHealth;           // Vida m�xima
    public int currentHealth;       // Vida atual
    public int damage;              // Dano do personagem
    public Slider healthSlider;     // Refer�ncia ao Slider da UI
    public bool isDefending;        // Se o personagem est� defendendo

    // M�todo para causar dano em outro personagem
    public void DealDamage(Character target)
    {
        int effectiveDamage = isDefending ? damage / 2 : damage;  // Se estiver defendendo, o dano � reduzido
        target.TakeDamage(effectiveDamage);
    }

    // Atualiza o slider de vida
    void UpdateHealthSlider()
    {
        healthSlider.value = (float)currentHealth / maxHealth;  // Atualiza a barra de vida com a vida atual
    }

    // M�todo para o personagem receber dano
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Subtrai o dano da vida atual
        if (currentHealth < 0)
        {
            currentHealth = 0;  // Garante que a vida n�o fique negativa
        }

        // Atualiza o slider ap�s sofrer dano
        UpdateHealthSlider();
    }

    // M�todo para resetar a defesa (caso o personagem pare de defender)
    public void ResetDefense()
    {
        isDefending = false;  // Reseta a defesa
    }
}