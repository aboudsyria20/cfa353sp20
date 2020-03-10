using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcherCharm : SceneCharacters
{
    [SerializeField] private DialogueOption m_letMeKnow;
    [SerializeField] private DialogueOption m_crying;
    [SerializeField] private DialogueOption m_rollingPin;
    [SerializeField] private DialogueOption m_end;


    [SerializeField] private PlayerController m_playerController;


    public override void ShowDialogue()
    {
         if (m_playerController.rollingPinInInventory)
        {
            m_dialoguePanel.Show(m_rollingPin);
        }
       else if (m_playerController.hadButchConvoTwo == true)
        {
            m_dialoguePanel.Show(m_end);
        }
        else if (m_playerController.butchCrying == true)
        {
            m_dialoguePanel.Show(m_crying);
        }
        else if (m_playerController.butchCurious == true)
        {
            m_dialoguePanel.Show(m_letMeKnow);
        }
        else
        {
            m_dialoguePanel.Show(m_initialOption);
        }

    }
}
