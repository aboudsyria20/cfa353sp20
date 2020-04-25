using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperSceneCharacter : SceneCharacters
{
    [SerializeField] private DialogueOption m_jellyDonutOption;
    [SerializeField] private DialogueOption m_scramOption;
    [SerializeField] private PlayerController m_playerController;
    

    public override void ShowDialogue()
    {
         if (m_playerController.hadDonutConvo == true)
        {
            m_dialoguePanel.Show(m_scramOption);
        }
         else if (m_playerController.psoInitalConvo == true && m_playerController.jellyDonutInInventory)
        {
            m_dialoguePanel.Show(m_jellyDonutOption);
        }
        else 
        {
            m_dialoguePanel.Show(m_initialOption);
        }
    }
}
