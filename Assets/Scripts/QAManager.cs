using TMPro;
using UnityEngine;

public class QAManager : MonoBehaviour
{
    [SerializeField] private Events events;

    [SerializeField] private QA[] questions;

    [SerializeField] private TMP_Text question;

    [SerializeField] private DistractorBehaviour[] distractors;

    private void Awake()
    {
        events.OnDistractorEnter += value =>
        {
            if (value)
            {
                for (int i = 0; i < distractors.Length; i++)
                {
                    distractors[i].Disable();
                }
            }
        };
    }

    private void Start()
    {
        var QA = questions[Random.Range(0, questions.Length)];

        question.text = QA.question;

        for (int i = 0; i < QA.distractors.Length && i < distractors.Length; i++)
        {
            var distractor = distractors[i];

            distractor.Text = QA.distractors[i].text;

            distractor.Value = QA.distractors[i].value;

            distractor.Selected += events.DistractorEnter;

            distractor.SetPosition(PlaygroundBuilder.DistractorPoints[i]);
        }
    }
}