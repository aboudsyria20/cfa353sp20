using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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

   
    //public bool mustHavemustHavePickedUpKey;
    //Barbetr Dialogue
    public bool hadBarberConvo;
    //Pawn Shop Owner 
    public bool hadJellyConvo = false;
    public bool hadPSOInitialConvo = false;
    public bool mustHaveJellyDonut;
    // Baker Dialogue
    public bool hadBakerRollingPinConvo;
    public bool hadInitialDialogue;
    public bool tellNoOne;
    // Butcher Dialogue
    public bool butchCrying;
    public bool butchCurious;
    public bool butchConvoTwo;
    //Win / Lose screen
    public bool playerWin;
    public bool playerLose;
    // making sure to talk to players
    public Characters mustTalkToCharacter;
    //Police Cheif 
    public bool talkedToChief;
    public bool mustHavePickedUpTicket;
    public bool givesJellyDonut;
    public bool willOpenBoat;
   

}



