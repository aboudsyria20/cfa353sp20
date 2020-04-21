using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class Characters : ScriptableObject
{
    [SerializeField] private string m_name;
    public string Name { get { return m_name; } }

   // [SerializeField] private Sprite m_interviewSprite;
   // public Sprite InterviewSprite { get { return m_interviewSprite; } }

    //[SerializeField] private AnimationClip m_animator;
    // public AnimationClip Animator { get { return m_animator; } }
    public AnimatorController animatorController;

}
