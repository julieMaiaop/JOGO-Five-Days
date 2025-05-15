using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeFont : MonoBehaviour
{
    [SerializeField] TMP_Text characterName, dialogueText, lastLineText;
    [SerializeField] TMP_FontAsset player, narrador, outros;
    void Update()
    {
        if (characterName.text == "Sofia")
        {
            characterName.font = player;
            dialogueText.font = player;
            lastLineText.font = player;
        }
        else if (characterName.text == "Cacique")
        {
            characterName.font = narrador;
            dialogueText.font = narrador;
            lastLineText.font = narrador;
        }
        else
        {
            characterName.font = outros;
            dialogueText.font = outros;
            lastLineText.font = outros;
        }
    }
}