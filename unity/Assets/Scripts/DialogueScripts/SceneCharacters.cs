using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCharacters : MonoBehaviour
{
    [SerializeField] private DialoguePanel m_dialoguePanel;
    [SerializeField] private Characters m_character;
    public Characters Character { get { return m_character; } }
    [SerializeField] private DialogueOption m_initialOption;

    public bool playerTalkedToMe = false;

    public void OnMouseDown()
    {
        playerTalkedToMe = true;
        
        m_dialoguePanel.SetCharacter(m_character);
        m_dialoguePanel.Show(m_initialOption);
    }
}
