using System.Collections;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{
    [SerializeField] string frase;
    [SerializeField] TMP_Text texto;
    [Range(0.001f, 1)]
    [SerializeField] float tempoIn, tempoMax;

    void Start()
    {
        StartCoroutine(AnimText());
    }

    IEnumerator AnimText()
    {
        //yield return new WaitForSeconds(6f);

        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(tempoIn);
        }

        yield return new WaitForSeconds(tempoMax);

        Destroy(texto);
    }

}