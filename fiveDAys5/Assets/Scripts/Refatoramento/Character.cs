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
        int effectiveDamage = isDefending ? 0 : damage; // Se est� defendendo, n�o toma dano
        target.TakeDamage(effectiveDamage);
    }

    // Atualiza a barra de vida
    void UpdateHealthSlider()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    // M�todo para o personagem receber dano
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthSlider();  // Atualiza a barra de vida
    }

    // M�todo para curar o personagem (se necess�rio no futuro)
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthSlider();  // Atualiza a barra de vida
    }

    // M�todo para resetar a defesa
    public void ResetDefense()
    {
        isDefending = false;
    }
}