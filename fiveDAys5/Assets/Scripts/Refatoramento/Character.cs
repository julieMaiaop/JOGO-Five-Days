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
        int effectiveDamage = isDefending ? 0 : damage; // Se está defendendo, não toma dano
        target.TakeDamage(effectiveDamage);
    }

    // Atualiza a barra de vida
    void UpdateHealthSlider()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    // Método para o personagem receber dano
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthSlider();  // Atualiza a barra de vida
    }

    // Método para curar o personagem (se necessário no futuro)
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthSlider();  // Atualiza a barra de vida
    }

    // Método para resetar a defesa
    public void ResetDefense()
    {
        isDefending = false;
    }
}