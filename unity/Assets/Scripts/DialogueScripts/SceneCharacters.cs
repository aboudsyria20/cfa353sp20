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
    public void Update()
    {
        //If space bar is pressed and the dialogue isn't activated already
        if (Input.GetKeyDown(KeyCode.Space) && m_dialoguePanel.gameObject.activeInHierarchy == false)
        {
            //Find player script
            PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
            Transform playerTransform = playerController.gameObject.transform;
            // Find the distance between player and NPC
            float distance = Vector3.Distance(playerTransform.position, this.transform.position);
            float minDsitance = 3.0f;
            //with in the talking radius
            if (distance < minDsitance)
            {
                Talk();
            }
        }

    }
    public void Talk()
    {
        playerTalkedToMe = true;

        m_dialoguePanel.SetCharacter(m_character);
       // StartCoroutine(m_dialoguePanel.ShowText());
       ShowDialogue();
    }

    public virtual void ShowDialogue()
    {

        m_dialoguePanel.Show(m_initialOption);
    }
}
