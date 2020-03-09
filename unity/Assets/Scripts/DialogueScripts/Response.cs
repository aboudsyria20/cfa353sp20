using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Response : MonoBehaviour
{
    [SerializeField] private Text m_text;

    private DialoguePanel m_dialoguePanel;
    private DialogueResponse m_response;
    [SerializeField] private PlayerController m_pc;

    //public GameObject winScreen;
    //public GameObject loseScreen;
    
    public void Set(DialoguePanel panel, DialogueResponse response)
    {
        m_dialoguePanel = panel;
        m_response = response;
        m_text.text = response.Response;
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }
   
    private void OnClick()
    {
        if (m_response.Option == null)
        {
            m_dialoguePanel.Hide();
        }
        else
        {
            m_dialoguePanel.Show(m_response.Option);
            // better way to do this, ask Matt for advice
            //Jelly dounut conversation
            if (m_response.hadJellyConvo == true)
            {
                m_dialoguePanel.PlayerController.hadDonutConvo = true;
            }
            // talked to cheif once
            if (m_response.talkedToChief == true)
            {
                m_dialoguePanel.PlayerController.talkedToChief = true;
            }
            // win or lose
            if(m_response.playerLose == true)
            {
                //loseScreen.SetActive(true);
                m_dialoguePanel.PlayerController.playerLose = true;
            }
            if (m_response.playerWin == true)
            {
              //  winScreen.SetActive(true);
               m_dialoguePanel.PlayerController.playerWin = true;
            }
           
        }
      
    }
}
