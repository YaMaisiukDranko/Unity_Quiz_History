using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Image = UnityEngine.UI.Image;


public class AnswerScript : MonoBehaviour
{
   public bool isCorrect = false;
   public QuizManager quizManager;

   public Color startColor;

   public void Start()
   {
      startColor = GetComponent<Image>().color;
   }

   
   public void Answer()
   {
      if (isCorrect)
      {
         GetComponent<Image>().color = Color.green;
         Debug.Log("Correct answer");
         quizManager.Correct();
      }
      else
      {
         GetComponent<Image>().color = Color.red;
         Debug.Log("Wrong Answer");
         quizManager.Wrong();
      }
   }
}
