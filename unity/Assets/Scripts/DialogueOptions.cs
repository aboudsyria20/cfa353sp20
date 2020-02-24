using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "ScriptableObjects/DialogueOption")]
public class DialogueOption : ScriptableObject
{
    [SerializeField] private string m_dialogue;
    public string dialogue { get { return m_dialogue; } set { m_dialogue = value; } }

    [SerializeField] private DialogueResponse[] m_responses;
    public DialogueResponse[] responses { get { return m_responses; } set { m_responses = value; } }
}

[System.Serializable]
public class DialogueResponse
{
    public string Response;
    public DialogueOption Option;
    public bool MustHavePickedUpJam;
    public bool MustHavePickedUpKey;
}