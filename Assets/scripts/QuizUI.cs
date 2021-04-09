using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private  QuizManager quizManager;
    [SerializeField] private  Text questionText,scoreText,panelText;
    [SerializeField] private  Image questionImg;
    [SerializeField] private  GameObject categoryMenu,gameMenu, panel,congats_Next_Class;
    [SerializeField] private  AudioSource questionClip;
    [SerializeField] private  List<Button> options, uiButtons;
    [SerializeField] private  Image ma8_tick, agglika_tick, glwssa_tick, istoria_tick,passed_img;
   // [SerializeField] private Color correctCol, wrongCol, normalCol;

    private Question question;
    private bool answered;
    private float audioLength;
    public int whatCategory;

    public Text ScoreText { get { return scoreText; } }
    public Text PanelText { get { return panelText; } }
    public GameObject Panel { get { return panel; } }

    private void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(Question question)
    {
        this.question = question;
        switch(question.questionType)
        {
            case QuestionType.TEXT:
                questionImg.transform.parent.gameObject.SetActive(false);
                break;

            case QuestionType.IMAGE:
                ImageHolder();
                questionImg.transform.gameObject.SetActive(true);
                questionImg.sprite = question.questionImg;
                break;

            case QuestionType.AUDIO:
                ImageHolder();
                questionClip.transform.gameObject.SetActive(true);
                audioLength = question.questionClip.length;
                StartCoroutine(PlayAudio());
                break;
        }

        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems <string>(question.options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
          //  options[i].image.color = normalCol;
        }
        answered = false;       
    }

    IEnumerator PlayAudio()
    {
        if(question.questionType == QuestionType.AUDIO)
        {
            questionClip.PlayOneShot(question.questionClip);
            yield return new WaitForSeconds(audioLength + 0.5f);
            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    void ImageHolder()
    {
        questionImg.transform.parent.gameObject.SetActive(true);
        questionImg.transform.gameObject.SetActive(false);
        questionClip.transform.gameObject.SetActive(false);
    }

    private void OnClick(Button btn)
    {
        if (quizManager.GameStatus == GameStatus.Playing)
        {
            if (!answered)
            {
                answered = true;
                quizManager.Answer(btn.name);
            }
        }

        switch(btn.name)
        {
            case "Ma8hmatika":
                quizManager.StartGame(0);
                categoryMenu.SetActive(false);
                gameMenu.SetActive(true);
                whatCategory = 0;
                break;
            case "Glwssa":
                quizManager.StartGame(1);
                categoryMenu.SetActive(false);
                gameMenu.SetActive(true);
                whatCategory = 1;
                break;
            case "Agglika":
                quizManager.StartGame(2);
                categoryMenu.SetActive(false);
                gameMenu.SetActive(true);
                whatCategory = 2;
                break;
            case "Istoria":
                quizManager.StartGame(3);
                categoryMenu.SetActive(false);
                gameMenu.SetActive(true);
                whatCategory = 3;
                break;
        }
    }//Onclick

    public void Passed()
    {
        if(quizManager.hasPassed)
        {
            if(whatCategory==0)
            {
                ma8_tick.transform.gameObject.SetActive(true);
            }
            else if (whatCategory ==1)
            {
                glwssa_tick.transform.gameObject.SetActive(true);
            }
            else if (whatCategory == 2)
            {
                agglika_tick.transform.gameObject.SetActive(true);
            }
            else if (whatCategory == 3)
            {
                istoria_tick.transform.gameObject.SetActive(true);
            }
        }
    }

    public bool PassedTheClass()
    {
        if (ma8_tick.isActiveAndEnabled && agglika_tick.isActiveAndEnabled && glwssa_tick.isActiveAndEnabled && istoria_tick.isActiveAndEnabled)
        {
            passed_img.gameObject.SetActive(true);
            gameMenu.SetActive(false);
            panel.SetActive(false);
            categoryMenu.SetActive(false);
            congats_Next_Class.SetActive(true);

            return true;
        }
        else {  return false;}    
    }

   public void RetryBtn()
    {
        Passed();
        gameMenu.SetActive(false);
        panel.SetActive(false);
        categoryMenu.SetActive(true);
        Debug.Log(PassedTheClass());
    }
}
