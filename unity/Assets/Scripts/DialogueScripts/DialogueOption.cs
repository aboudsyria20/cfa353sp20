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
    public bool mustHavePickedUpJam;
    public bool mustHavePickedUpKey;
    public bool mustHavePickedUpTicket;
    public bool mustHaveJellyDonut;
   // public bool mustHavePawnInformation;
   // public bool mustHaveBarberInformation;
  //  public bool canOpenFishersBoat;
  //  public bool canOpenChest;
    public bool playerWin;
    public bool playerLose;
    public Characters mustTalkToCharacter;
    public bool talkedToChief;
    public bool hadJellyConvo = false;

}



