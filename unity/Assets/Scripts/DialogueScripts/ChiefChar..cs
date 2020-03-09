using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiefChar : SceneCharacters
{
    [SerializeField] private DialogueOption m_ticket;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private DialogueOption m_chooseKiller;
    [SerializeField] private DialogueOption m_intro;
    [SerializeField] private DialogueOption m_foundRollingPin;
    [SerializeField] private DialogueOption m_foundTicket;

    [SerializeField] private DialogueOption m_gameOver;


    public override void ShowDialogue()
    {
        if (m_playerController.deliTicketInInventory)
        {
            m_dialoguePanel.Show(m_ticket);
        }
        else if (m_playerController.rollingPinInventory == true)
        {
            m_dialoguePanel.Show(m_gameOver);
        }
        else
        {
            m_dialoguePanel.Show(m_initialOption);
        }

    }



}
