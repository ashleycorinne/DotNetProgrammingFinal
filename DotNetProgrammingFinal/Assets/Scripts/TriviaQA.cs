using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class TriviaQA {

	public List<TriviaQuestion> TriviaQuestions { get; set; }

    public bool IsCorrectAnswer(int id, char guess)
    {
        TriviaQuestion q = TriviaQuestions.Where(x => x.Id == id).FirstOrDefault();
        if (q!= null && q.Answer == guess)
            return true;
        return false;
    }

    public TriviaQuestion GetRandomTriviaQuestion()
    {
        TriviaQuestion q = new TriviaQuestion() ;
        if (TriviaQuestions.Count > 0)
        {
            q = TriviaQuestions[0];
            TriviaQuestions.RemoveAt(0);
            return TriviaQuestions[0];
        }
        return q;
    }

  

    public void GetTriviaQuestions()
    {
       
    }

    public class TriviaQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public char Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

    }
}

