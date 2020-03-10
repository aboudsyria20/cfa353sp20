using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiefChar : SceneCharacters
{
    [SerializeField] private DialogueOption m_foundRollingPin;
    [SerializeField] private DialogueOption m_ticket;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private DialogueOption m_gameOver;


    public override void ShowDialogue()
    {

         if (m_playerController.rollingPinInInventory )
        {
            m_dialoguePanel.Show(m_gameOver);
        }
         //plays if you have talked to the cheif once
        else if (m_playerController.talkedToChief == true)
        {
            m_dialoguePanel.Show(m_ticket);
        }
        else
        {
            m_dialoguePanel.Show(m_initialOption);
        }

    }



}
