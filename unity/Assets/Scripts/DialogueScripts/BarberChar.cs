using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarberChar : SceneCharacters
{

    
    [SerializeField] private DialogueOption m_end;
    [SerializeField] private PlayerController m_playerController;


    public override void ShowDialogue()
    {
        if (m_playerController.hadBarberConvo == true)
        {
            m_dialoguePanel.Show(m_end);
        }
        else
        {
            m_dialoguePanel.Show(m_initialOption);
        }
    }
}
