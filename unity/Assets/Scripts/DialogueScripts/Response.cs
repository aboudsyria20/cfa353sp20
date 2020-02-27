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
        }
    }
}
