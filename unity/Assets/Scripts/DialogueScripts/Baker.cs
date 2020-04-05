 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baker : SceneCharacters
{

    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private DialogueOption m_tellNoOne;
    [SerializeField] private DialogueOption m_rollingPin;
    [SerializeField] private DialogueOption m_end;

    public override void ShowDialogue()
    {
          if (m_playerController.rollingPinInInventory)
        {
            m_dialoguePanel.Show(m_rollingPin);
        }
       else if (m_playerController.hadRollingPinConvo == true)
        {
            m_dialoguePanel.Show(m_end);
        }
        else if (m_playerController.tellNoOne == true)
        {
            m_dialoguePanel.Show(m_tellNoOne);
        }

        else
        {
            m_dialoguePanel.Show(m_initialOption);
            m_playerController.jellyDonutInInventory = true;
        }
      }
    }
