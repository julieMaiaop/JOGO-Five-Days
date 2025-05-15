using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] string nameScene, nameTag;
    [SerializeField] GameObject disableObj;
    [SerializeField] bool isSave;

    string saveKey;

    void Start()
    {
        // Criar uma chave única para salvar no PlayerPrefs
        if (isSave && disableObj != null)
        {
            saveKey = $"{SceneManager.GetActiveScene().name}_{disableObj.name}_DISABLED";

            // Verifica se já foi salvo como "desativado"
            if (PlayerPrefs.GetInt(saveKey, 0) == 1)
            {
                disableObj.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameTag))
        {
            // Salva se necessário
            if (isSave && disableObj != null)
            {
                PlayerPrefs.SetInt(saveKey, 1); // Marca como "desativado"
                PlayerPrefs.Save();
            }

            // Troca de cena
            SceneManager.LoadScene(nameScene);
        }
    }
}