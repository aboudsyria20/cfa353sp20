using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "DialogeOption")]
public class DialogueOptions : MonoBehaviour
{
    public string m_Dialogue;

    public DialogueResponse[] m_responses;

}
[System.Serializable]
public class DialogueResponse
{
    public string Response;
    public DialogueOptions Option;
    //Storing data
                // public Evidence[] RequiredEvidence;
}