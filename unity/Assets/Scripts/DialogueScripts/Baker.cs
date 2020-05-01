 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baker : SceneCharacters
{

    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private DialogueOption m_tellNoOne;
    [SerializeField] private DialogueOption m_rollingPin;
    [SerializeField] private DialogueOption m_end;
    [SerializeField] private DialogueOption m_haveJelly;
    [SerializeField] private DialogueOption m_gaveJelly;

    public override void ShowDialogue()
    {
         
       if (m_playerController.hadRollingPinConvo == true)
        {
            m_dialoguePanel.Show(m_end);
        }
        else if (m_playerController.rollingPinInInventory)
        {
            m_dialoguePanel.Show(m_rollingPin);
        }
        else if (m_playerController.tellNoOne == true)
        {
            m_dialoguePanel.Show(m_tellNoOne);
        }
       else if (m_playerController.gaveJellyDoughnut == true)
        {
            m_dialoguePanel.Show(m_gaveJelly);
        }
          else if (m_playerController.jarOfJamInInventory == true && m_playerController.hadInitialDialogue == true )
        {
            m_playerController.jellyDonutInInventory = true;
            m_dialoguePanel.Show(m_haveJelly);
        }

        else
        {
            m_dialoguePanel.Show(m_initialOption);
           
        }
      }
    }
