using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private  List<QuizDataScpt> quizData;
    [SerializeField] private List<Question> questions;
 
    private Question selectedQuestion;
    public int scoreCount;
    public bool hasPassed = false;
    private GameStatus gameStatus = GameStatus.Next;

    public GameStatus GameStatus { get { return gameStatus; } }

    public void StartGame(int sub)
    {
        scoreCount = 0;
        questions = new List<Question>();
        for (int i = 0; i < quizData[sub].questions.Count; i++)
        {
            questions.Add(quizData[sub].questions[i]);
        }
        SelectQuestion();
        quizUI.ScoreText.text = "Βαθμός: " + scoreCount;
        gameStatus = GameStatus.Playing;

    }//StartGame

    void SelectQuestion()
    {
        int rdm = UnityEngine.Random.Range(0, questions.Count);//dialegei enan ari8mo anamesa stis erwthseis pou exoume
        selectedQuestion = questions[rdm]; //h erwthsh pou etuxe einai to stoixeio ths listas
        quizUI.SetQuestion(selectedQuestion); //kai tn arxikopoioume
        questions.RemoveAt(rdm);//tn afairei apo thn lista
    }//selectQuestion

    public bool Answer(string answered)
    {
        bool correctAns = false;

        if(answered == selectedQuestion.correctAnswer)
        {
            //yes
            correctAns = true;
            scoreCount += 1;
            quizUI.ScoreText.text = "Βαθμός: " + scoreCount;
        }

        if (gameStatus == GameStatus.Playing)
        {
            if(questions.Count >0)//elegxei an exoun teleiwsei oi erwthseis apo thn lista
            {
                Invoke("SelectQuestion", 0.4f); //kanei wait prin paei sto next question
            }else
            {
                gameStatus = GameStatus.Next;
                quizUI.Panel.SetActive(true);
                if (scoreCount >= 1)
                {
                    quizUI.PanelText.text = "ΣΥΓΧΑΡΗΤΗΡΙΑ ΠΕΡΑΣΕΣ ΤΟ ΜΑΘΗΜΑ ΜΕ " + scoreCount + " ΣΩΣΤΕΣ ΑΠΑΝΤΗΣΕΙΣ !!";
                    hasPassed = true;
                }
                else
                {
                    quizUI.PanelText.text = "ΔΥΣΤΥΧΩΣ ΔΕΝ ΚΑΤΑΦΕΡΕΣ ΝΑ ΠΕΡΑΣΕΙΣ ΤΟ ΜΑΘΗΜΑ, ΕΙΧΕΣ ΜΟΝΟ " + scoreCount + " ΣΩΣΤΕΣ ΑΠΑΝΤΗΣΕΙΣ" + "\n ΚΑΛΗ ΤΥΧΗ ΤΝ ΕΠΟΜΕΝΗ ΦΟΡΑ !";
                    hasPassed = false;
                }
            }//if
        }
        return correctAns;
    }//Answer

}//QuizManager
    
[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImg;
    public AudioClip questionClip;
    public List<string> options;
    public string correctAnswer;
}

 
[System.Serializable]
public enum QuestionType
{
    TEXT,
    AUDIO,
    IMAGE
}

[System.Serializable]
public  enum GameStatus
{
    Next,
    Playing
}
    