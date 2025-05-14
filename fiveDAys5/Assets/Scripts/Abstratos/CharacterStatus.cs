using UnityEngine;

public abstract class CharacterStatus : MonoBehaviour
{
    // Velocidade do personagem (intervalo de 0 a 10)
    [Range(0, 10)]
    [SerializeField] float speed;

    // Vida do personagem
    [SerializeField] int vida;

    // Propriedades públicas para acessar e modificar os valores
    public float Speed { get => speed; set => speed = value; }
    public int Vida { get => vida; set => vida = value; }
}