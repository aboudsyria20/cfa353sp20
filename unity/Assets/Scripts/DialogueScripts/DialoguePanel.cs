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

    [SerializeField] private PlayerController m_playerController;

    public void SetCharacter(Characters character)
    {
        m_characterImage.sprite = character.InterviewSprite;
        m_characterImage.SetNativeSize();
    }

    public void Show(DialogueOption dialogueOption)
    {
        this.gameObject.SetActive(true);

        m_dialogueField.text = dialogueOption.dialogue;

        while (m_buttonParent.childCount > 0)
        {
            Transform child = m_buttonParent.GetChild(0);
            child.SetParent(null);
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < dialogueOption.responses.Length; i++)
        {
            
            DialogueResponse response = dialogueOption.responses[i];
            if(response.mustHavePickedUpKey && !m_playerController.keyInInventory)
            {
                continue; //don't spawn the button
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