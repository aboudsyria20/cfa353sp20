using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCharacters : MonoBehaviour
{
    [SerializeField] protected DialoguePanel m_dialoguePanel;
    [SerializeField] private Characters m_character;
    public Characters Character { get { return m_character; } }
    [SerializeField] protected DialogueOption m_initialOption;

    public bool playerTalkedToMe = false;

    public void OnMouseDown()
    {
        playerTalkedToMe = true;
        
        m_dialoguePanel.SetCharacter(m_character);

        ShowDialogue();
    }

    public virtual void ShowDialogue()
    {
        m_dialoguePanel.Show(m_initialOption);
    }
}
