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

    public void SetCharacter(Characters character)
    {
        m_characterImage.sprite = character.InterviewSprite;
        m_characterImage.SetNativeSize();
    }

    public void Show(DialogueOptions dialogueOption)
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