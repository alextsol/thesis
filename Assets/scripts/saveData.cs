using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveData 
{
    private int Category, Score;
    public saveData(QuizManager quizManager,QuizUI quizUI)
    {
        Category = quizUI.whatCategory;
        Score = quizManager.scoreCount;
    }



}
