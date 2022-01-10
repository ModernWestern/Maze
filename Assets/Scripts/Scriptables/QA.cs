using System;
using UnityEngine;

[CreateAssetMenu(fileName = "QA", menuName = "ScriptableObjects/QA", order = 4)]
public class QA : ScriptableObject
{
    public string question;

    public Distractor[] distractors;
}

[Serializable]
public class Distractor
{
    public string text;

    public bool value;

    public string feedback;
}