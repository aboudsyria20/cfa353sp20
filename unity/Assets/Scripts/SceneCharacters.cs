using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCharacters : MonoBehaviour
{
    [SerializeField] private DialoguePanel m_dialoguePanel;
    [SerializeField] private Characters m_character;
    [SerializeField] private DialogueOptions m_initialOption;

    public void OnMouseDown()
    {
        m_dialoguePanel.SetCharacter(m_character);
        m_dialoguePanel.Show(m_initialOption);
    }
}
