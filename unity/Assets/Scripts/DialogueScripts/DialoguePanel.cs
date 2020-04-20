using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    [SerializeField] private Text m_dialogueField;
    [SerializeField] private Image m_characterImage;
    [SerializeField] private Transform m_buttonParent;
    [SerializeField] private GameObject m_responsePrefab;
    [SerializeField] private float delay = 0.1f;

    public GameObject buttonGroup;
    string myDialogue = "";
    private DialogueOption m_dialogueOption;


    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private DialogueOption dialogueOption;

    public PlayerController PlayerController { get { return m_playerController; } }
   // public DialogueOption DialogueOption { get { return dialogueOption; } }
    public void Update()
    {
        if (m_dialogueOption != null)
        {
            if (Input.anyKeyDown)
            {
                StopAllCoroutines();
                //skip to end
                m_dialogueField.text = m_dialogueOption.dialogue;
                buttonGroup.SetActive(true);
            }
        }
    }
    public void SetCharacter(Characters character)
    {
        m_characterImage.sprite = character.InterviewSprite;
        m_characterImage.SetNativeSize();
    }
    //Typwirter Effect for the dialogue
    IEnumerator ShowText(string dialogue, float delay)
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            buttonGroup.SetActive(false);
            m_dialogueField.text = dialogue.Substring(0, i);
            string visibleText = dialogue.Substring(0, i);
            string invisibleText = "<color=#FFFFFF00>" + dialogue.Substring(i, dialogue.Length - 1 - i) + "</color>";
            yield return new WaitForSeconds(delay);
            buttonGroup.SetActive(true);
        }
    }

    public void Show(DialogueOption dialogueOption)
    {
        m_dialogueOption = dialogueOption;

        this.gameObject.SetActive(true);
       
        StartCoroutine(ShowText(dialogueOption.dialogue, delay));
       
      // m_dialogueField.text = dialogueOption.dialogue;

        while (m_buttonParent.childCount > 0)
        {
            Transform child = m_buttonParent.GetChild(0);
            child.SetParent(null);
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < dialogueOption.responses.Length; i++)
        {
            
            DialogueResponse response = dialogueOption.responses[i];
          
            if(response.mustHavePickedUpTicket && !m_playerController.deliTicketInInventory)
            {
                continue;
            }

            bool hasMetCharacterRequirement = true;
            if(response.mustTalkToCharacter != null) //have a character that we need to talk to
            {
                SceneCharacters[] allCharacters = GameObject.FindObjectsOfType<SceneCharacters>();
                for(int j=0; j<allCharacters.Length; j++)
                {
                    Characters character = allCharacters[j].Character;
                    if(character == null) continue; //just in case the character is not assigned
                    if(response.mustTalkToCharacter.Name == character.Name) //we've found the character we need
                    {
                        if(!allCharacters[j].playerTalkedToMe)
                        {
                            hasMetCharacterRequirement = false;
                        }
                    }
                }
            }

            if(!hasMetCharacterRequirement)
            {
                continue;
            }
            

            GameObject buttonObject = Instantiate(m_responsePrefab, m_buttonParent);
            Response button = buttonObject.GetComponent<Response>();
            button.Set(this, dialogueOption.responses[i]);

        }
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}