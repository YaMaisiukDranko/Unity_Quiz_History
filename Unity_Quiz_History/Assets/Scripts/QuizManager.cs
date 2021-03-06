using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GgPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    private int totalQuestions = 0 ;
    public int score;

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void Start()
    {
        totalQuestions = QnA.Count;
        GgPanel.SetActive(false);
        GenerateQuestion();
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GgPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void Correct()
    {
        //when you say correct
        score += 1;
        QnA.RemoveAt(currentQuestion);
        //GenerateQuestion();
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        //when wrong
        QnA.RemoveAt(currentQuestion);
        //GenerateQuestion();
        StartCoroutine(WaitForNext());
    }
    
    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds((float)1.7); 
        GenerateQuestion();
    }

    void SetAnswers()
    {
        
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }
    }
}
