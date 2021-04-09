using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="QustionData", menuName = "QuestionDate")]
public class QuizDataScpt : ScriptableObject
{
    public List<Question> questions;
}
